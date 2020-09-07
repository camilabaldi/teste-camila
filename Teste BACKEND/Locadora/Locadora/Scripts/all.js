
$(document).ready(function () {

    $('.cep').mask('00000-000');
    $('.tel').mask('(00)0000-0000');
    $('.cpf').mask('000.000.000-00');
    $('.dt').mask('00/00/0000');

    //colocando data
    $('#data').val(dataFormatada);

    //listagem de dados 

    $.ajax({
        url: urlBase + 'Helpers/ListarClientes/',
        type: 'POST',
        datatype: 'application/json',
        success: function (data) {

            var cli = "";

            if (data.length > 0) {
                cli = cli + "<option value='' selected>Selecione Um Cliente</option>";
                for (var i = 0; i < data.length; i++) {
                    cli = cli + "<option value='" + data[i].ID + "' " + (data[i].ID == "Selecione Um Cliente" ? "selected" : "") + ">" + data[i].Nome + "</option>";
                }
            }
            $("#cli").append(cli);
        },
        error: function () {
            FecharAguarde();
            var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
        }
    });

    $.ajax({
        url: urlBase + 'Helpers/ListarFilmes/',
        type: 'POST',
        datatype: 'application/json',
        success: function (data) {

            var fil = "";

            if (data.length > 0) {
                fil = fil + "<option value='' selected>Selecione Um Filme</option>";
                for (var i = 0; i < data.length; i++) {
                    fil = fil + "<option value='" + data[i].ID + "' " + (data[i].ID == "Selecione Um Filme" ? "selected" : "") + ">" + data[i].Nome + "</option>";
                }
            }
            $("#fil").append(fil);
        },
        error: function () {
            FecharAguarde();
            var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
        }
    });

    //listar as locações
    $.ajax({
        url: urlBase + 'Helpers/BuscaLoc/',
        type: 'POST',
        datatype: 'application/json',
        success: function (data) {
            var html = '';

            if (data.length > 0) {
                for (var i = 0; i < data.length; i++) {
                    html = html + '<tr>';
                    html = html + '<td><input readonly class="form-control " value="' + data[i].ID + '" required/></td>';
                    html = html + '<td><input readonly class="form-control " value="' + data[i].NAMECLI + '" required/></td>';
                    html = html + '<td><input readonly class="form-control " value="' + data[i].NAMEFIL + '" required/></td>';
                    html = html + '<td><input readonly class="form-control " value="' + data[i].DATA + '" required/></td>';
                    html = html + '<td><input readonly class="form-control " value="' + data[i].DATADEV + '" required/></td>';

                    //DATA 
                    var date1 = data[i].DATADEV;
                    var date1a = date1.toString().substring(0, 2); //dia 
                    var date1b = date1.toString().substring(3, 5); //mes 
                    var date1c = date1.toString().substring(6); //ano

                    date1 = (date1b + "/" + date1a + "/" + date1c).toString();
                    date1 = new Date(date1);

                    var date2 = new Date(dataFormatadaDev());

                    var days = (date2 - date1) / (1000 * 60 * 60 * 24);
                    days = parseInt(days);


                    //console.log(days);

                    if (date2 > date1) {
                        html = html + '<td><input readonly style="color:red" class="form-control text-center" value="' + days + '" required/></td>';
                    } else {
                        html = html + '<td><input readonly class="form-control text-center" value="-" required/></td>';
                    }
                    html = html + '<td><a type="button" style="margin-left:18%" onClick="devolve(\'' + data[i].ID + '\', \'' + data[i].IDFIL + '\')" value="' + data[i].ID + '" class="btn btn-xs btn-warning j-devolve" >Devolver</a>';
                    html = html + '<td class="hidden"><input name="itens[]" class="itens" type="hidden" ' +
                        'value="' + data[i].ID +
                        '|' + data[i].NAMECLI +
                        '|' + data[i].NAMEFIL +
                        '|' + data[i].DATA +
                        '|' + data[i].DATADEV +
                        '|' + days +
                        '|' + data[i].ID +
                        '" /></td>';
                }

                $('#tbItens tbody').append(html);
            }
        },
        error: function () {
            FecharAguarde();
            var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
        }
    });

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

$(document).on('click', '#btn_salvarLoc', function () {
    $.ajax({
        url: urlBase + 'Helpers/CadastrarLoc/',
        type: 'POST',
        datatype: 'application/json',
        data: {
            idFil: $("#fil").val(), idCli: $("#cli").val(), data: $("#data").val(), dataDev: $("#dataDev").val()
        },
        success: function (data) {
            if (data.text == "Locação feita com sucesso!") {
                var exibeScs = data.text;
                Sucesso(exibeScs);

                //limpa form
                //$(".fil").val('');

            } else if (data != "") {
                var exibe = data.text;
                Erro(exibe);

            } else {
                console.log("Não retornou nenhum objeto da f(x)Controller: Helpers/CadastrarLoc/");
            }
        },
        error: function () {
            var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
        }
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

function dataFormatada() {
    var data = new Date(),
        dia = data.getDate(),
        mes = data.getMonth() + 1,
        ano = data.getFullYear();

    return [dia, mes, ano].join('/');
}

function dataFormatadaDev() {
    var data = new Date(),
        dia = data.getDate(),
        mes = data.getMonth() + 1,
        ano = data.getFullYear();

    return [mes, dia, ano].join('/');
}

function devolve(id, idFil) {

    $.ajax({
        url: urlBase + 'Helpers/Devolver/',
        type: 'POST',
        datatype: 'application/json',
        data: {
            idLoc: id, idFilm: idFil
        },
        success: function (data) {
            if (data.text == "Devolução realizada com sucesso!") {
                var exibeScs = data.text;
                Sucesso(exibeScs);

                //carrega pagina novamente
                //

            } else if (data != "") {
                var exibe = data.text;
                Erro(exibe);

            } else {
                console.log("Não retornou nenhum objeto da f(x)Controller: Helpers/Devolver/");
            }
        },
        error: function () {
            var n = noty({ text: 'ERRO AO PROCESSAR REQUISIÇÃO.', timeout: 2000, type: 'error' });
        }
    });
}

