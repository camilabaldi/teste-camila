//var urlBase = window.location.origin + '/NFe/';
var urlBase = window.location.origin + '/';

function Aguarde() {
    $('#modalAguarde').modal({ backdrop: 'static', keyboard: false });
}

function FecharAguarde() {
    $('#modalAguarde').modal('hide');
}

function validaCPF(cpf) {
    // Elimina CPFs invalidos conhecidos
    if (cpf == "00000000000" ||
        cpf == "11111111111" ||
        cpf == "22222222222" ||
        cpf == "33333333333" ||
        cpf == "44444444444" ||
        cpf == "55555555555" ||
        cpf == "66666666666" ||
        cpf == "77777777777" ||
        cpf == "88888888888" ||
        cpf == "99999999999")
        return false;

    var numeros, digitos, soma, i, resultado, digitos_iguais;
    digitos_iguais = 1;
    if (cpf.length < 11)
        return false;
    for (i = 0; i < cpf.length - 1; i++)
        if (cpf.charAt(i) != cpf.charAt(i + 1)) {
            digitos_iguais = 0;
            break;
        }
    if (!digitos_iguais) {
        numeros = cpf.substring(0, 9);
        digitos = cpf.substring(9);
        soma = 0;
        for (i = 10; i > 1; i--)
            soma += numeros.charAt(10 - i) * i;
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(0))
            return false;
        numeros = cpf.substring(0, 10);
        soma = 0;
        for (i = 11; i > 1; i--)
            soma += numeros.charAt(11 - i) * i;
        resultado = soma % 11 < 2 ? 0 : 11 - soma % 11;
        if (resultado != digitos.charAt(1))
            return false;
        return true;
    }
    else
        return false;
}


function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function SomenteNumero(e) {
    var tecla = (window.event) ? event.keyCode : e.which;
    if ((tecla > 47 && tecla < 58)) return true;
    else {
        if (tecla == 8 || tecla == 0) return true;
        else return false;
    }
}

function removerAcentos(newStringComAcento) {
    var string = newStringComAcento;
    var mapaAcentosHex = {
        a: /[\xE0-\xE6]/g,
        A: /[\xC0-\xC6]/g,
        e: /[\xE8-\xEB]/g,
        E: /[\xC8-\xCB]/g,
        i: /[\xEC-\xEF]/g,
        I: /[\xCC-\xCF]/g,
        o: /[\xF2-\xF6]/g,
        O: /[\xD2-\xD6]/g,
        u: /[\xF9-\xFC]/g,
        U: /[\xD9-\xDC]/g,
        c: /\xE7/g,
        C: /\xC7/g,
        n: /\xF1/g,
        N: /\xD1/g,
    };

    for (var letra in mapaAcentosHex) {
        var expressaoRegular = mapaAcentosHex[letra];
        string = string.replace(expressaoRegular, letra);
    }

    return string;
}

function load() {
    $('div#camada', window.parent.document).show();
}

function loaded() {
    $('div#camada', window.parent.document).hide();
}

function loadImportar() {
    $('div#camada', window.parent.document).fadeOut(4000);
}

function Erro(mensagemErro) {
    $('#modalErro').modal('show');
    $("#mensagemErro").html(mensagemErro);
}

function Sucesso(mensagemSucesso) {
    $('#modalSucesso').modal('show');
    $("#mensagemSucesso").html(mensagemSucesso);
}

function Alerta(mensagemAlerta) {
    $('#modalAlerta').modal('show');
    $("#mensagemAlerta").html(mensagemAlerta);
}

$(function () {
    $('div#camada', window.parent.document).hide();
});

var modalSucesso = "";
modalSucesso = modalSucesso + '	<div class="modal fade" id="modalSucesso">';
modalSucesso = modalSucesso + '		<div class="modal-dialog">';
modalSucesso = modalSucesso + '			<div class="modal-content emerald">';
modalSucesso = modalSucesso + '				<div class="modal-header">';
modalSucesso = modalSucesso + '					<button type="button" class="close" data-dismiss="modal">&times;</button>';
modalSucesso = modalSucesso + '					<h3 class="modal-title"style="background-color:initial">';
modalSucesso = modalSucesso + '						<span class="glyphicon glyphicon-ok"></span>&nbsp;&nbsp;';
modalSucesso = modalSucesso + '						Sucesso';
modalSucesso = modalSucesso + '					</h3>';
modalSucesso = modalSucesso + '				</div>';
modalSucesso = modalSucesso + '				<div class="modal-body" style="background-color:white">';
modalSucesso = modalSucesso + '					<br />';
modalSucesso = modalSucesso + '					<p id="mensagemSucesso"></p>';
modalSucesso = modalSucesso + '				</div>';
modalSucesso = modalSucesso + '			</div>';
modalSucesso = modalSucesso + '		</div>';
modalSucesso = modalSucesso + '	</div>';

var modalErro = "";
modalErro = modalErro + '	<div class="modal fade" id="modalErro">';
modalErro = modalErro + '		<div class="modal-dialog">';
modalErro = modalErro + '			<div class="modal-content pomegranate">';
modalErro = modalErro + '				<div class="modal-header">';
modalErro = modalErro + '					<button type="button" class="close" data-dismiss="modal">&times;</button>';
modalErro = modalErro + '					<h3 class="modal-title" style="background-color:initial">';
modalErro = modalErro + '						<span class="glyphicon glyphicon-remove"></span>&nbsp;&nbsp;';
modalErro = modalErro + '						Erro';
modalErro = modalErro + '					</h3>';
modalErro = modalErro + '				</div>';
modalErro = modalErro + '				<div class="modal-body" style="background-color:white">';
modalErro = modalErro + '					<p id="mensagemErro"></p>';
modalErro = modalErro + '				</div>';
//modalErro = modalErro + '				<div class="modal-footer" style="background-color:white">';
//modalErro = modalErro + '                   <button class="btn" style="float:right" data-dismiss="modal" > OK</button>';
//modalErro = modalErro + '				</div>';
modalErro = modalErro + '			</div>';
modalErro = modalErro + '		</div>';
modalErro = modalErro + '	</div>';

var modalWarning = "";
modalWarning = modalWarning + '	<div class="modal fade" id="modalAlerta">';
modalWarning = modalWarning + '		<div class="modal-dialog">';
modalWarning = modalWarning + '			<div class="modal-content sun-flower">';
modalWarning = modalWarning + '				<div class="modal-header">';
modalWarning = modalWarning + '					<button type="button" class="close" data-dismiss="modal">&times;</button>';
modalWarning = modalWarning + '					<h3 class="modal-title" style="background-color:initial">';
modalWarning = modalWarning + '						<span class="glyphicon glyphicon-warning-sign"></span>&nbsp;&nbsp;';
modalWarning = modalWarning + '						Aviso';
modalWarning = modalWarning + '					</h3>';
modalWarning = modalWarning + '				</div>';
modalWarning = modalWarning + '				<div class="modal-body" style="background-color:white">';
modalWarning = modalWarning + '					<p id="mensagemAlerta"></p>';
modalWarning = modalWarning + '				</div>';
modalWarning = modalWarning + '			</div>';
modalWarning = modalWarning + '		</div>';
modalWarning = modalWarning + '	</div>';

$(document).ready(function () {

    $(".body").append(modalSucesso);
    $(".body").append(modalErro);
    $(".body").append(modalWarning);

    $(".noty").click(function () {

    });
});