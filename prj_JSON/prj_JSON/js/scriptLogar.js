const txtLogin = document.getElementById('txtLogin');
const txtSenha = document.getElementById('txtSenha');
const localMensagem = document.querySelector('.mensagem');
const textoMensagem = document.querySelector('#mensagemTexto')


const btnEntrar = document.querySelector('#btnEntrar');

if (btnEntrar) 
    btnEntrar.addEventListener('click', function (e) {
        e.preventDefault();
        txtLogin.setAttribute('disabled', true);
        txtSenha.setAttribute('disabled', true);
        this.setAttribute('disabled', true);
        this.innerHTML = "<span class='material-symbols-outlined'> hourglass_empty</span> Aguarde";
        localMensagem.classList.add('escondido');

        if (txtLogin.value == '')
        {
            textoMensagem.innerHTML = 'Login deve ser digitado!';
            localMensagem.classList.remove('escondido');
            txtLogin.removeAttribute('disabled', true);
            txtSenha.removeAttribute('disabled', true);
            btnEntrar.removeAttribute('disabled', true);
            btnEntrar.innerHTML = "<span class='material-symbols-outlined'>login</span> Entrar";

        }
        if (txtSenha.value == '') {
            textoMensagem.innerHTML = 'Senha deve ser digitada!';
            localMensagem.classList.remove('escondido');
            txtLogin.removeAttribute('disabled', true);
            txtSenha.removeAttribute('disabled', true);
            btnEntrar.removeAttribute('disabled', true);
            btnEntrar.innerHTML = "<span class='material-symbols-outlined'>login</span> Entrar";

        }

        const formData = new FormData;
        formData.append('l', txtLogin.value);
        formData.append('s', txtSenha.value);

        fetch('lib/acessar.aspx' , {
            method: 'post',
            body: formData
        })
            .then(function (response) {
                return response.json();
            })
            .then(function (data) {
                console.log(data);
                if (data['situacao'] == 'false') {
                    textoMensagem.innerHTML = 'Login e/ou Senha Inválido!';
                    localMensagem.classList.remove('escondido');
                    txtLogin.removeAttribute('disabled', true);
                    txtSenha.removeAttribute('disabled', true);
                    btnEntrar.removeAttribute('disabled', true);
                    btnEntrar.innerHTML = "<span class='material-symbols-outlined'>login</span> Entrar";
                }
                else {
                    console.log('FUNCIONA!');
                    window.location.href = "principal.aspx";
                }
            })
            .catch(function (error) {
                console.error('Erro ao buscar os dados:', error);
            });



    });



