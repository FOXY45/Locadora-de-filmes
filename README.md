conteudo_readme = """# 🎬 Locadora de Filmes

Projeto desenvolvido com o objetivo de simular o funcionamento de uma locadora de filmes com controle de filiais, funcionários, estoque e cadastro de títulos.

Este projeto serve como protótipo funcional, com backend completo em C# e estrutura preparada para integração com interface gráfica via Avalonia.

---

## 🛠 Tecnologias utilizadas

- **C# 8.0+**
- **.NET 8**
- **Entity Framework Core** (com SQLite no protótipo)
- **MySQL** (previsto para versão final)
- **Avalonia UI** (interface gráfica futura)
- **VS Code / Visual Studio**
- Git e GitHub

---

## 📁 Estrutura do Projeto

LocadoraDeFilmes/
│
├── Models/ # Entidades do banco de dados (Filial, Funcionario, Setor)
├── Services/ # Serviços de CRUD (FilialService, FuncionarioService, SetorService)
├── SQL/ # Scripts SQL (tabelas, procedures, triggers)
│
├── Views/ # [interface Avalonia] Telas em XAML (em branco, para expansão futura)
├── ViewModels/ # [interface Avalonia] Lógica das Views (em branco, para expansão futura)
├── Resources/ # Estilos, imagens e arquivos estáticos (em branco)
│
├── Program.cs # Menu de texto atual com operações básicas de Filial
├── LocadoraDbContext.cs # Contexto do banco com os DbSets principais
├── CRA.csproj # Arquivo de projeto (renomeado)
├── .gitignore
├── .gitattributes
└── README.md # Este arquivo


---

## ✅ Funcionalidades já implementadas

- [x] CRUD completo de **Filiais** com controle de nome, endereço, faturamento e custos
- [x] CRUD completo de **Funcionários** com setor, nível de acesso, salário e faltas
- [x] CRUD completo de **Setores** (Gerência, Balcão, Estoquistas etc)
- [x] Relacionamentos entre entidades com EF Core
- [x] Estrutura pronta para expansão multi-filial
- [x] Organização modular com **Models** e **Services**
- [x] Banco SQLite funcional e adaptável para MySQL
- [x] Preparação para interface gráfica via Avalonia

---

## 🔜 Funcionalidades planejadas

- [ ] Sistema de **login com níveis de acesso** (Funcionário / Administrador)
- [ ] Cadastro e filtragem de **filmes por gênero, nota e sinopse**
- [ ] Registro de **entradas e saídas** de estoque
- [ ] Scripts de **procedures e triggers SQL**
- [ ] Integração com **Avalonia UI**
- [ ] Interface gráfica amigável e funcional

---

## 🤝 Contribuição

Caso esteja participando do projeto:

1. Faça um fork ou clone do repositório:
   ```bash
   git clone https://github.com/FOXY45/Locadora-de-filmes
2. Crie uma nova branch ou atualize sua local

3. Faça suas alterações com commits claros

4. Envie um pull request, ou envie diretamente se for colaborador

💡 Observações

    Se você é da equipe responsável pela interface gráfica, os arquivos já estão organizados nas pastas Views/, ViewModels/ e Resources/.

    Caso encontre qualquer problema com namespaces, importações ou contextos, verifique os using, a pasta correta, e se o arquivo está referenciado no .csproj.

📌 Autor da Estrutura

Este projeto foi estruturado por Fellipe dos Santos Godinho, estudante de Sistemas de Informação na Urcamp de Bagé, com foco na organização de código, alimentação do banco de dados e suporte à equipe de frontend. As pastas gráficas foram adicionadas para facilitar a visualização da arquitetura completa.
📄 Licença

Este projeto é apenas para fins didáticos e não possui licença comercial.
"""