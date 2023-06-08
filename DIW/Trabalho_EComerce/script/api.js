function loadCategories() {
    fetch('https://fakestoreapi.com/products/categories')
        .then(res => res.json())
        .then(json => {
            let idContainer = 'selectTiposProdutos'
            let container = document.getElementById(idContainer)

            json.forEach(item => {
                // Criar um elemento <option> para cada item
                const option = document.createElement('option');
                option.value = item; // Definir o valor do <option>
                option.text = item; // Definir o texto do <option>

                // Adicionar o <option> ao <select>
                container.appendChild(option);
            });
        })
        .catch(error => {
            console.log('Ocorreu um erro ao carregar o select:', error)
        })
}

function getProductsInitialGrid() {
    fetch('https://fakestoreapi.com/products?limit=9')
        .then(res => res.json())
        .then(json => {
            let idContainer = 'containerCards'
            let container = document.getElementById(idContainer)

            json.forEach(item => {
                // Criar elementos HTML para exibir as informações
                let card = document.createElement('div')
                card.classList.add('card', 'col-lg-4', 'col-md-4', 'col-sm-6', 'text-center', 'produto', 'produtoClick')
                card.setAttribute('data-id', item.id)

                card.addEventListener('click', function () {
                    // Obter o ID único do atributo de dados do card
                    var id = this.getAttribute('data-id');
                    var url = './detalhes.html?id=' + id
                    window.location.href = url;
                });

                let cardBody = document.createElement('div')
                cardBody.classList.add('card-body')

                let imagem = document.createElement('img')
                imagem.src = item.image
                imagem.alt = item.title
                imagem.classList.add('card-img-top')

                let titulo = document.createElement('h5')
                titulo.classList.add('card-title')
                titulo.textContent = item.title;

                let preco = document.createElement('p')
                preco.classList.add('card-text')
                preco.textContent = 'Preço: $' + item.price

                // Adicionar elementos ao card
                cardBody.appendChild(titulo)
                cardBody.appendChild(preco)

                card.appendChild(imagem)
                card.appendChild(cardBody)

                // Adicionar o card ao container
                container.appendChild(card)
            });
        })
        .catch(error => {
            console.log('Ocorreu um erro ao inicializar o grid:', error)
        })
}

function getMostViewd() {
    fetch('https://fakestoreapi.com/products?limit=3')
        .then(res => res.json())
        .then(json => {
            let idContainer = 'ContainerMaisVistos'
            let container = document.getElementById(idContainer)

            json.forEach(item => {
                // Criar elementos HTML para exibir as informações
                let card = document.createElement('div')
                card.classList.add('card', 'col-lg-4', 'col-md-6', 'col-sm-12', 'text-center', 'produtoClick')
                card.setAttribute('data-id', item.id)

                card.addEventListener('click', function () {
                    // Obter o ID único do atributo de dados do card
                    var id = this.getAttribute('data-id');
                    var url = './detalhes.html?id=' + id
                    window.location.href = url;
                });

                let cardBody = document.createElement('div')
                cardBody.classList.add('card-body')

                let div = document.createElement('div')
                div.classList.add('imgDestaque')

                let imagem = document.createElement('img')
                imagem.src = item.image
                imagem.alt = item.title
                imagem.classList.add('imgPequena')

                let titulo = document.createElement('p')
                titulo.textContent = item.title;

                // Adicionar elementos ao card
                div.appendChild(imagem)
                div.appendChild(titulo)

                cardBody.appendChild(div);

                card.appendChild(cardBody)

                // Adicionar o card ao container
                container.appendChild(card)
            });
        })
        .catch(error => {
            console.log('Ocorreu um erro ao Carregar o most viewd:', error)
        })
}

function getCarroussel() {
    fetch('https://fakestoreapi.com/products?limit=3')
        .then(res => res.json())
        .then(json => {
            let idContainer = 'CarrosselCards'
            let container = document.getElementById(idContainer)
            let itemCont = 0;

            json.forEach(item => {
                // Criar elementos HTML para exibir as informações
                let card = document.createElement('div')
                card.classList.add('carousel-item')
                if (itemCont === 0) {
                    card.classList.add('active')
                }

                let imagem = document.createElement('img')
                imagem.src = item.image
                imagem.alt = item.description
                imagem.classList.add('d-block', 'w-100')

                // Adicionar elementos ao card
                card.appendChild(imagem)

                // Adicionar o card ao container
                container.appendChild(card)
            });
        })
        .catch(error => {
            console.log('Ocorreu um erro ao obter os dados da API:', error)
        })
}

function getDetalhes() {
    var query = location.search.slice(1);

    var partes = query.split('&');
    console.log(partes)
    var valor

    partes.forEach(function (parte) {
        var chaveValor = parte.split('=');
        var chave = chaveValor[0];
        valor = chaveValor[1];
        console.log(chave)
        console.log(valor)
    });

    fetch('https://fakestoreapi.com/products/' + valor)
        .then(res => res.json())
        .then(json => {
            let idContainer = 'ContainerNovoCard'
            let container = document.getElementById(idContainer)


            // Criar elementos HTML para exibir as informações
            let card = document.createElement('div')
            card.classList.add('card', 'col-12')

            let imagem = document.createElement('img')
            imagem.src = json.image
            imagem.alt = json.title
            imagem.classList.add('card-img-top')


            let titulo = document.createElement('h5')
            titulo.classList.add('card-title')
            titulo.textContent = json.title;

            let categoria = document.createElement('p')
            categoria.classList.add('card-text')
            categoria.textContent = json.category

            let detalhes = document.createElement('p')
            detalhes.classList.add('card-text')
            detalhes.textContent = json.description

            let preco = document.createElement('p')
            preco.classList.add('card-text')
            preco.textContent = 'Preço: $' + json.price

            // Adicionar elementos ao card
            card.appendChild(titulo)
            card.appendChild(imagem)
            card.appendChild(categoria)
            card.appendChild(preco)
            card.appendChild(detalhes)

            // Adicionar o card ao container
            container.appendChild(card)

        })
        .catch(error => {
            console.log('Ocorreu um erro ao obter os detalhes do produto:', error)
        })
}

function getProductsSearchCategory() {
    var query = location.search.slice(1);

    var partes = query.split('&');
    console.log(partes)
    var valor

    partes.forEach(function (parte) {
        var chaveValor = parte.split('=');
        var chave = chaveValor[0];
        valor = chaveValor[1];
        console.log(chave)
        console.log(valor)
    });

    fetch('https://fakestoreapi.com/products/category/' + valor)
        .then(res => res.json())
        .then(json => {
            let idContainer = 'containerCardsPesquisa'
            let container = document.getElementById(idContainer)

            json.forEach(item => {
                // Criar elementos HTML para exibir as informações
                let card = document.createElement('div')
                card.classList.add('card', 'col-lg-4', 'col-md-4', 'col-sm-6', 'text-center', 'produto', 'produtoClick')
                card.setAttribute('data-id', item.id)

                card.addEventListener('click', function () {
                    // Obter o ID único do atributo de dados do card
                    var id = this.getAttribute('data-id');
                    localStorage.setItem('idDetalhes', id);
                    var url = './detalhes.html?id=' + id
                    window.location.href = url;
                });

                let cardBody = document.createElement('div')
                cardBody.classList.add('card-body')

                let imagem = document.createElement('img')
                imagem.src = item.image
                imagem.alt = item.title
                imagem.classList.add('card-img-top')

                let titulo = document.createElement('h5')
                titulo.classList.add('card-title')
                titulo.textContent = item.title;

                let preco = document.createElement('p')
                preco.classList.add('card-text')
                preco.textContent = 'Preço: $' + item.price

                // Adicionar elementos ao card
                cardBody.appendChild(titulo)
                cardBody.appendChild(preco)

                card.appendChild(imagem)
                card.appendChild(cardBody)

                // Adicionar o card ao container
                container.appendChild(card)
            });
        })
        .catch(error => {
            console.log('Ocorreu um erro ao pesquisar pela categoria:', error)
        })
}
