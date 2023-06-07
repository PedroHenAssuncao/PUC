function getProductsInitialGrid() {
    fetch('https://fakestoreapi.com/products?limit=9')
        .then(res => res.json())
        .then(json => {
            let idContainer = 'containerCards'
            let container = document.getElementById(idContainer)

            json.forEach(item => {
                // Criar elementos HTML para exibir as informações
                let card = document.createElement('div')
                card.classList.add('card', 'col-lg-4', 'col-md-4', 'col-sm-6', 'text-center', 'produto','produtoClick')

                let cardBody = document.createElement('div')
                cardBody.classList.add('card-body')

                let imagem = document.createElement('img')
                imagem.src = item.image
                imagem.alt = item.description
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
            console.log('Ocorreu um erro ao obter os dados da API:', error)
        })
}

function getMostViewd(){
    fetch('https://fakestoreapi.com/products?limit=3')
        .then(res => res.json())
        .then(json => {
            let idContainer = 'ContainerMaisVistos'
            let container = document.getElementById(idContainer)

            json.forEach(item => {
                // Criar elementos HTML para exibir as informações
                let card = document.createElement('div')
                card.classList.add('card', 'col-lg-4', 'col-md-6', 'col-sm-12', 'text-center','produtoClick')

                let cardBody = document.createElement('div')
                cardBody.classList.add('card-body')

                let div = document.createElement('div')
                div.classList.add('imgDestaque')

                let imagem = document.createElement('img')
                imagem.src = item.image
                imagem.alt = item.description
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
            console.log('Ocorreu um erro ao obter os dados da API:', error)
        })
}

function getCarroussel(){
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
                if(itemCont === 0){
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