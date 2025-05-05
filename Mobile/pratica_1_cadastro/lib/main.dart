import 'package:flutter/material.dart';

void main() {
  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Cadastro',
      theme: ThemeData(
        colorScheme: ColorScheme.fromSeed(seedColor: Colors.amber),
      ),
      home: const MyHomePage(title: 'Cadastro'),
    );
  }
}

class MyHomePage extends StatefulWidget {
  const MyHomePage({super.key, required this.title});

  final String title;

  @override
  State<MyHomePage> createState() => _MyHomePageState();
}

class _MyHomePageState extends State<MyHomePage> {
  bool _obscurePassword = true;
  String _selectGender = "m";
  double fontSize = 15;

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        backgroundColor: Theme.of(context).colorScheme.inversePrimary,
        title: Text(widget.title),
      ),
      body: Center(
          child: FractionallySizedBox(
            widthFactor: 0.9,
            heightFactor: 0.9,
            child: Padding(
              padding: const EdgeInsets.all(16.0),
              child: ListView(
                children: <Widget>[
                  TextField(
                    keyboardType: TextInputType.text,
                    decoration: InputDecoration(
                      labelText: 'Nome',
                    ),
                    maxLength: 50,
                  ),
                  SizedBox(height: 16.0),
                  TextField(
                    keyboardType: TextInputType.emailAddress,
                    decoration: InputDecoration(
                      labelText: 'Email',
                    ),
                    maxLength: 50,
                  ),
                  SizedBox(height: 16.0),
                  TextField(
                    obscureText: _obscurePassword,
                    decoration: InputDecoration(
                      labelText: 'Senha',
                      suffixIcon: IconButton(
                        icon: Icon(
                          _obscurePassword ? Icons.visibility : Icons.visibility_off,
                        ),
                        onPressed: () {
                          setState(() {
                            _obscurePassword = !_obscurePassword;
                          });
                        },
                      ),
                    ),
                    maxLength: 16,
                  ),
                  SizedBox(height: 16.0),
                  Row(
                    children: [
                      Text("Gênero: ", style: TextStyle(fontSize:fontSize)),
                      Row(
                        children: [
                          Text("Masculino", style: TextStyle(fontSize:fontSize)),
                          Radio(
                            value: "m",
                            groupValue: _selectGender,
                            onChanged: (context) {
                              setState(() {
                                _selectGender = "m";
                              });
                            },
                          ),
                          Text("Feminino", style: TextStyle(fontSize:fontSize)),
                          Radio(
                            value: "f",
                            groupValue: _selectGender,
                            onChanged: (context) {
                              setState(() {
                                _selectGender = "f";
                              });
                            },
                          ),
                        ],
                      ),
                    ],
                  ),
                  SizedBox(height: 16.0),
                  Align(
                    alignment: Alignment.centerLeft,
                    child: Text("Font-Size:", style: TextStyle(fontSize:fontSize)),
                  ),
                  SizedBox(height: 10.0),
                  Slider(
                    value: fontSize,
                    min: 15,
                    max: 65,
                    divisions: 10,
                    onChanged: (valor) {
                      setState(() {
                        fontSize = valor;
                      });
                    },
                  ),
                  SizedBox(height: 16.0),
                  ElevatedButton(
                    onPressed: () {
                    },
                    style: ElevatedButton.styleFrom(
                      backgroundColor: Theme.of(context).colorScheme.inversePrimary,
                      foregroundColor: Colors.deepPurple,
                    ),
                    child: Text('Cadastrar', style: TextStyle(fontSize:fontSize)),
                  )
                ],
              ),
            ),
          ),
        ),
    );
  }
}