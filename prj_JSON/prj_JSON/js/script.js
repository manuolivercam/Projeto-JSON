fetch('lib/listarUsuarios.aspx')
    .then(function (response) {
        return response.json();
    })
    .then(function (data) {
        console.log(data);
        const divUsuarios = document.querySelector('#usuarios');
        let resposta = "";
        for (var i = 0; i < data.length; i++)
        {
            resposta += `<p>${data[i]["Nome"]}</p>`;
        }
        divUsuarios.innerHTML = resposta;

    })
    .catch(function (error) {
        console.error('Erro ao buscar os dados:', error);
    });


