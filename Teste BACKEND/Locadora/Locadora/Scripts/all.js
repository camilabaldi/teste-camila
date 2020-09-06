
$(document).ready(function () {

    $('.cep').mask('00000-000');
    $('.tel').mask('(00)0000-0000');
    $('.cpf').mask('000.000.000-00');

    $(document).on('click', '#btn_salvarCli', function () {
        load();
        ValidarCliente();
        loaded();
    });

    $(document).on('click', '#btn_salvarFil', function () {
        $.ajax({
            url: urlBase + 'Helpers/CadastrarFil/',
            type: 'POST',
            datatype: 'application/json',
            data: {
                nome: $("#nomeFil").val(), autor: $("#autFil").val(), ano: $("#anoFil").val()
            },
            success: function (data) {
                if (data.text == "Filme cadastrado com sucesso!") {
                    var exibeScs = data.text;
                    Sucesso(exibeScs);

                    //limpa form
                    $(".fil").val('');

                } else if (data != "") {
                    var exibe = data.text;
                    Erro(exibe);

                } else {
                    console.log("Não retornou nenhum objeto da f(x)Controller: Helpers/CadastrarFil/");
                }
            },
            error: function () {
                var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
            }
        });
    });
});

function ValidarCliente() {

    $.ajax({
        url: urlBase + 'Helpers/ValidarCli/',
        type: 'POST',
        datatype: 'application/json',
        data: {
            nome: $("#nomeCli").val(), cpf: $("#cpfCli").val()
        },
        success: function (data) {
            if (data.text == "Cliente ja cadastrado") {
                var exibeErr = data.text;
                Erro(exibeErr);

                //Limpando campos
                $("#nomeCli").val('');
                $("#cpfCli").val('');

            } else {
                console.log("Cliente disp.");

                $.ajax({
                    url: urlBase + 'Helpers/CadastrarCli/',
                    type: 'POST',
                    datatype: 'application/json',
                    data: {
                        nome: $("#nomeCli").val(), cpf: $("#cpfCli").val(), idade: $("#idadeCli").val(), tel: $("#telCli").val(), cep: $("#cepCli").val(), num: $("#numCli").val(), email: $("#emailCli").val()
                    },
                    success: function (data) {
                        if (data.text == "Cliente cadastrado com sucesso!") {
                            var exibeScs = data.text;
                            Sucesso(exibeScs);

                            //limpa form
                            $(".cli").val('');

                        } else if (data != "") {
                            var exibe = data.text;
                            Alerta(exibe);

                        } else {
                            console.log("Não retornou nenhum objeto da f(x)Controller: Helpers/CadastrarCli/");
                        }
                    },
                    error: function () {
                        var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
                    }
                });
            }
        },
        error: function () {
            var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
        }
    });
}



