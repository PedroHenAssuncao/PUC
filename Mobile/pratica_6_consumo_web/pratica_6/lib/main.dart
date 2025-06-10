import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

void main() {
  runApp(const MaterialApp(
    home: CepPage(),
    debugShowCheckedModeBanner: false,
  ));
}

class CepPage extends StatefulWidget {
  const CepPage({super.key});

  @override
  State<CepPage> createState() => _CepPageState();
}

class _CepPageState extends State<CepPage> {
  final TextEditingController _cepController = TextEditingController();
  Map<String, dynamic> _dadosCep = {};
  String? _erro;

  Future<void> _buscarCep() async {
    final cep = _cepController.text.trim();

    try {
      final response = await http.get(Uri.parse('https://viacep.com.br/ws/$cep/json/'));

      if (response.statusCode == 200) {
        final data = jsonDecode(response.body);
        if (data.containsKey('erro')) {
          setState(() {
            _erro = 'CEP não encontrado.';
            _dadosCep = {};
          });
        } else {
          setState(() {
            _dadosCep = data;
            _erro = null;
          });
        }
      } else {
        setState(() {
          _erro = 'Erro ao buscar CEP.';
        });
      }
    } catch (e) {
      setState(() {
        _erro = 'Erro de conexão.';
      });
    }
  }

  Widget _buildCampo(String label, String? value) {
    return TextField(
      readOnly: true,
      decoration: InputDecoration(
        labelText: label,
        border: const OutlineInputBorder(),
      ),
      controller: TextEditingController(text: value ?? ''),
    );
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text('Consulta CEP')),
      body: Padding(
        padding: const EdgeInsets.all(16),
        child: ListView(
          children: [
            TextField(
              controller: _cepController,
              keyboardType: TextInputType.number,
              decoration: const InputDecoration(
                labelText: 'Digite o CEP',
                border: OutlineInputBorder(),
              ),
            ),
            const SizedBox(height: 12),
            ElevatedButton(
              onPressed: _buscarCep,
              child: const Text('Buscar'),
            ),
            const SizedBox(height: 16),
            if (_erro != null)
              Text(_erro!, style: const TextStyle(color: Colors.red)),
            if (_dadosCep.isNotEmpty) ...[
              _buildCampo('Logradouro', _dadosCep['logradouro']),
              const SizedBox(height: 8),
              _buildCampo('Complemento', _dadosCep['complemento']),
              const SizedBox(height: 8),
              _buildCampo('Bairro', _dadosCep['bairro']),
              const SizedBox(height: 8),
              _buildCampo('Localidade', _dadosCep['localidade']),
              const SizedBox(height: 8),
              _buildCampo('UF', _dadosCep['uf']),
            ],
          ],
        ),
      ),
    );
  }
}