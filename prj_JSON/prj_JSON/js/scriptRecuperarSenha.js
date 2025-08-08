const txtEmail = document.querySelector('#txtEmail');
const btnEnviar = document.querySelector('#btnEnviar');
const localMensagem = document.querySelector('.mensagem');
const textoMensagem = document.querySelector('#mensagemTexto')

if (btnEnviar)
    btnEnviar.addEventListener('click', function (e) {
        e.preventDefault();
        txtEmail.setAttribute('disabled', true);
        this.setAttribute('disabled', true);
        this.innerHTML = "<span class='material-symbols-outlined'> hourglass_empty</span> Aguarde";
        localMensagem.classList.add('escondido');

        if (txtEmail.value == '') {
            textoMensagem.innerHTML = 'E-mail deve ser digitado!';
            localMensagem.classList.remove('escondido');
            txtEmail.removeAttribute('disabled', true);
            btnEnviar.removeAttribute('disabled', true);
            btnEnviar.innerHTML = "<span class='material-symbols-outlined'>mail</span> Enviar";

        }
     
        const formData = new FormData;
        formData.append('l', txtEmail.value);

        fetch('lib/recuperarSenha.aspx', {
            method: 'post',
            body: formData
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (data) {
                console.log(data);
                if (data['situacao'] == 'false') {
                    textoMensagem.innerHTML = 'E-mail inválido!';
                    localMensagem.classList.remove('escondido');
                    txtEmail.removeAttribute('disabled', true);
                    btnEnviar.removeAttribute('disabled', true);
                    btnEnviar.innerHTML = "<span class='material-symbols-outlined'>mail</span> Enviar";
                    console.log('deu ruim');
                }
                else {
                    console.log('FUNCIONA!');
                    textoMensagem.innerHTML = 'E-mail enviado com sucesso!';
                    localMensagem.classList.remove('msgErro');
                    localMensagem.classList.remove('escondido');
                    localMensagem.classList.add('msgSucesso');
                    txtEmail.removeAttribute('disabled', true);
                    btnEnviar.removeAttribute('disabled', true);
                    btnEnviar.innerHTML = "<span class='material-symbols-outlined'>mail</span> Enviar";
                }
            })
            .catch(function (error) {
                console.error('Erro ao buscar os dados:', error);
            });



    });
