import 'package:flutter/material.dart';
import 'package:sqflite/sqflite.dart';
import 'package:path/path.dart';

void main() {
  runApp(const App());
}

class App extends StatelessWidget {
  const App({super.key});

  @override
  Widget build(BuildContext context) {
    return const MaterialApp(
      home: Home(),
    );
  }
}

class Home extends StatefulWidget {
  const Home({super.key});

  @override
  State<Home> createState() => _HomeState();
}

class _HomeState extends State<Home> {
   List<Map<String, dynamic>> _alunos = [];

  // Método para recuperar ou abrir o banco de dados
  _recuperarBD() async {
    final caminho = await getDatabasesPath();
    final local = join(caminho, "bancodados.db");

    var retorno = await openDatabase(
      local,
      version: 1,
      onCreate: (db, dbVersaoRecente) {
        String sql = "CREATE TABLE usuarios ("
            "id INTEGER PRIMARY KEY AUTOINCREMENT, "
            "matricula TEXT UNIQUE, "
            "nome VARCHAR, "
            "idade INTEGER, "
            "curso TEXT)";
        db.execute(sql);
      },
    );

    return retorno;
  }

  // Método para inserir um novo usuário no banco de dados
  _salvarDados(BuildContext context, String nome, int idade, String matricula, String curso) async {
    Database db = await _recuperarBD();

    // Dados a serem inseridos, representados como um mapa
     Map<String, dynamic> dadosUsuario = {
      "matricula": matricula,
      "nome": nome,
      "idade": idade,
      "curso": curso,
    };

    // Insere os dados na tabela 'usuarios' e retorna o ID do novo registro
    int id = await db.insert("usuarios", dadosUsuario);
    print("Salvo $id");

    // Exibe um diálogo para o usuário confirmar que o registro foi salvo
    _mostrarDialogo(context, "Usuário salvo com sucesso!");
  }

  // Método para exibir diálogos de confirmação e mensagens
  _mostrarDialogo(BuildContext context, String mensagem) {
    showDialog(
      context: context,
      builder: (BuildContext context) {
        return AlertDialog(
          title: const Text("Resultado"),
          content: Text(mensagem),
          actions: [
            TextButton(
              onPressed: () {
                Navigator.of(context).pop();
              },
              child: const Text("OK"),
            ),
          ],
        );
      },
    );
  }

  // Método para listar todos os usuários armazenados no banco de dados
  _listarUsuarios() async {
    Database db = await _recuperarBD();
    String sql = "SELECT * FROM usuarios";
    List<Map<String, dynamic>> usuarios = await db.rawQuery(sql);

    setState(() {
      _alunos = usuarios;
    });
  }

  // Método para listar um usuário específico com base no ID
  _listarUmUsuario(BuildContext context, String matricula) async {
    Database db = await _recuperarBD();

    // Faz a consulta na tabela 'usuarios' com o ID fornecido
    List usuarios = await db.query(
      "usuarios",
      columns: ["id", "nome", "idade", "matricula", "curso"],
      where: "matricula = ?",
      whereArgs: [matricula],
    );

    // Verifica se o usuário existe e exibe um diálogo com as informações
    if (usuarios.isNotEmpty) {
      var usuario = usuarios.first;
      _mostrarDialogo(context,
          "ID: ${usuario['id']} \nNome: ${usuario['nome']} \nIdade: ${usuario['idade']} \nMatrícula: ${usuario['matricula']} \nCurso: ${usuario['curso']}");
    } else {
      _mostrarDialogo(context, "Usuário com Matricula: $matricula não encontrado.");
    }
  }

  // Método para excluir um usuário com base no ID
  _excluirUsuario(BuildContext context, String matricula) async {
    Database db = await _recuperarBD();

    // Exclui o registro de acordo com o ID fornecido
    int retorno = await db.delete(
      "usuarios",
      where: "matricula = ?",
      whereArgs: [matricula],
    );

    print("Itens excluídos: $retorno");

    // Exibe um diálogo para confirmar a exclusão
    _mostrarDialogo(context, "Usuário com Matricula: $matricula excluído com sucesso.");
  }

  // Método para atualizar informações de um usuário existente
  _atualizarUsuario(BuildContext context) async {
    Database db = await _recuperarBD();

    String matricula = _matriculaController.text;
    String nome = _nomeController.text;
    int? idade = int.tryParse(_idadeController.text);
    String curso = _cursoController.text;

    if (matricula.isEmpty) {
      _mostrarDialogo(context, "Informe a matrícula para atualizar.");
      return;
    }

    Map<String, dynamic> dadosAtualizados = {};
    if (nome.isNotEmpty) dadosAtualizados['nome'] = nome;
    if (idade != null) dadosAtualizados['idade'] = idade;
    if (curso.isNotEmpty) dadosAtualizados['curso'] = curso;

    if (dadosAtualizados.isEmpty) {
      _mostrarDialogo(context, "Preencha algum campo para atualizar.");
      return;
    }

    // Realiza a atualização caso existam campos para modificar
    if (dadosAtualizados.isNotEmpty) {
      int retorno = await db.update(
        "usuarios",
        dadosAtualizados,
        where: "matricula = ?",
        whereArgs: [matricula],
      );

      print("Itens atualizados: $retorno");
      _mostrarDialogo(context, "Usuário com Matricula: $matricula atualizado com sucesso.");
    } else {
      _mostrarDialogo(context, "Nenhuma informação para atualizar.");
    }
  }

  final TextEditingController _nomeController = TextEditingController();
  final TextEditingController _idadeController = TextEditingController();
  final TextEditingController _matriculaController = TextEditingController();
  final TextEditingController _cursoController = TextEditingController();

  @override
  void initState() {
    super.initState();
    _listarUsuarios();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        alignment: Alignment.center,
        child: Column(
          mainAxisSize: MainAxisSize.max,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Container(
              margin: const EdgeInsets.all(0.5),
              width: 300,
              alignment: Alignment.center,
              child: TextField(
                controller: _nomeController,
                decoration: const InputDecoration(
                  label: Text("Digite o nome:"),
                ),
              ),
            ),
            const Padding(padding: EdgeInsets.all(10)),
            Container(
              margin: const EdgeInsets.all(0.5),
              width: 300,
              alignment: Alignment.center,
              child: TextField(
                controller: _idadeController,
                decoration: const InputDecoration(
                  label: Text("Digite a idade:"),
                ),
                keyboardType: TextInputType.number,
              ),
            ),
            Container(
              margin: const EdgeInsets.all(0.5),
              width: 300,
              alignment: Alignment.center,
              child: TextField(
                controller: _matriculaController,
                decoration: const InputDecoration(
                  label: Text("Digite a matricula:"),
                ),
                keyboardType: TextInputType.text,
              ),
            ),
            Container(
              margin: const EdgeInsets.all(0.5),
              width: 300,
              alignment: Alignment.center,
              child: TextField(
                controller: _cursoController,
                decoration: const InputDecoration(
                  label: Text("Digite o curso:"),
                ),
                keyboardType: TextInputType.text,
              ),
            ),
            const SizedBox(height: 10),
            ElevatedButton(
              onPressed: () {
                _salvarDados(context, _nomeController.text,
                    int.tryParse(_idadeController.text) ?? 0, _matriculaController.text, _cursoController.text);
              },
              child: const Text("Salvar um usuário"),
            ),
            const SizedBox(height: 10),
            ElevatedButton(
              onPressed: _listarUsuarios,
              child: const Text("Listar todos usuários"),
            ),
            const SizedBox(height: 10),
            Container(
              margin: const EdgeInsets.all(0.5),
              width: 300,
              alignment: Alignment.center,
              child: TextField(
                controller: _matriculaController,
                decoration: const InputDecoration(
                  label: Text(
                      "Digite a matricula do aluno para listar/excluir/atualizar:"),
                ),
                keyboardType: TextInputType.text,
              ),
            ),
            const SizedBox(height: 10),
            ElevatedButton(
              onPressed: () {
                String matricula = _matriculaController.text;
                if (matricula.isNotEmpty) {
                  _listarUmUsuario(context, matricula);
                } else {
                  _mostrarDialogo(
                      context, "Por favor, insira uma matricuka válida para listar.");
                }
              },
              child: const Text("Listar um usuário"),
            ),
            const SizedBox(height: 10),
            ElevatedButton(
              onPressed: () {
                String matricula = _matriculaController.text;
                if (matricula.isNotEmpty) {
                  _excluirUsuario(context, matricula);
                } else {
                  _mostrarDialogo(
                      context, "Por favor, insira uma matricula válida para excluir.");
                }
              },
              child: const Text("Excluir usuário"),
            ),
            const SizedBox(height: 10),
            ElevatedButton(
              onPressed: () {
                String matricula = _matriculaController.text;
                if (matricula.isNotEmpty) {
                  _atualizarUsuario(context);
                } else {
                  _mostrarDialogo(context,
                      "Por favor, insira um ID válido para atualizar.");
                }
              },
              child: const Text("Atualizar usuário"),
            ),
             Expanded(
              child: _alunos.isEmpty ? const Center(child: Text("Nenhum aluno cadastrado."))
                : SingleChildScrollView(
                    scrollDirection: Axis.horizontal,
                    child: DataTable(
                      columns: const [
                        DataColumn(label: Text('Matrícula')),
                        DataColumn(label: Text('Nome')),
                        DataColumn(label: Text('Idade')),
                        DataColumn(label: Text('Curso')),
                      ],
                      rows: _alunos
                          .map(
                            (aluno) => DataRow(
                              cells: [
                                DataCell(Text(aluno['matricula'] ?? '')),
                                DataCell(Text(aluno['nome'] ?? '')),
                                DataCell(Text(aluno['idade'].toString())),
                                DataCell(Text(aluno['curso'] ?? '')),
                              ],
                            ),
                          )
                          .toList(),
                    ),
                  ),
             ),
          ],
        ),
      ),
    );
  }
}
