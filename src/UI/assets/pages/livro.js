var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(function () { BindControlEvents(); });

function BindControlEvents() {
    $("#form1").validationEngine('attach', { addFailureCssClassToField: "error", showPrompts: true, autoPositionUpdate: true, scroll: false }).bind("jqv.form.result", function (event, errorFound) { if (errorFound) $("#btnSalvar").attr("disabled", false).html("Salvar"); });

    $('[class*=required]').each(function (e) {
        $(this).attr("style", "border-left-width: 2px;border-left-style: solid;border-left-color: rgb(202, 20, 2);");
    });

    Consultar();
    $("[id$=btnNovo]").click(function () {
        $("input[type=text]").each(function () {
            $(this).val("");
        });
        $("[id$=lModalTitulo]").text('Cadastro de Motivo de cancelamento da perícia');
        $("#modalcadastro").show();
        LimparCampos();
        $("[id$=hdd_ACAO]").val("I");
        $("[id$=hdd_ID]").val("");
    });

    $("[id$=btnFechar]").click(function () {
        $("#modalcadastro").hide();
    });

    $("[id$=btnCloseModalCadastro]").click(function () {
        $("#modalcadastro").hide();
    });

    $("[id$=btnSalvar]").click(function () {
        if ($("#form1").validationEngine('validate') == false)
            return false;
        else {
            $.ajax({
                type: "POST",
                timeout: 10000,
                url: "MotivoCancelamentoPericia.aspx/Salvar",
                data: '{txt_PROCESSO_LAUDO_PERICIA_MOTIVO_CANCELAMENTO_PERICIA_DESCRICAO: "' + $("[id$=txt_PROCESSO_LAUDO_PERICIA_MOTIVO_CANCELAMENTO_PERICIA_DESCRICAO]").val() + '",Acao: "' + $("[id$=hdd_ACAO]").val() + '",id: "' + $("[id$=hdd_ID]").val() + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (json) {
                    $('.modal-backdrop').remove();
                    $("#modalcadastro").hide();
                    if ($("[id$=hdd_ACAO]").val() == "I")
                        Command: toastr["success"]("Cadastro realizado com sucesso!", "Atenção!");
                    else
                        Command: toastr["success"]("Cadastro atualizado com sucesso!", "Atenção!");
                    Consultar();
                },
                error: function (x, t, m) {

                }
            });
        }
    });

    $("[id$=btnConsultar]").click(function () {
        Consultar();

    });
    function Consultar() {
        $.ajax({
            type: "GET",
            url: "Default.aspx/BindDatatable",            
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                var parsed = $.parseJSON(data.d);

                var table = $('.display').dataTable({
                    destroy: true,
                    "aaData": parsed,
                    searching: true,
                    bFilter: false,

                    "pagingType": "full_numbers",
                    "ordering": false,
                    "language": {
                        "sEmptyTable": "Nenhum registro encontrado",
                        "sInfo": "Mostrando de _START_ até _END_ de _TOTAL_ registros",
                        "sInfoEmpty": "Mostrando 0 até 0 de 0 registros",
                        "sInfoFiltered": "(Filtrados de _MAX_ registros)",
                        "sInfoPostFix": "",
                        "sInfoThousands": ".",
                        "sLengthMenu": "_MENU_ resultados por página",
                        "sLoadingRecords": "Carregando...",
                        "sProcessing": "Processando...",
                        "sZeroRecords": "Nenhum registro encontrado",
                        "sSearch": "Pesquisar",
                        "oPaginate": {
                            "sNext": "Próximo",
                            "sPrevious": "Anterior",
                            "sFirst": "Primeiro",
                            "sLast": "Último"
                        },
                        "oAria": {
                            "sSortAscending": ": Ordenar colunas de forma ascendente",
                            "sSortDescending": ": Ordenar colunas de forma descendente"
                        }
                    },
                    "columns": [
                        {
                            data: null,
                            defaultContent: ' <a href="" class="btn btn-default btn-xs editor_edit"><i class="fa fa-pencil-square-o"></i></a>'
                        },
                        {
                            data: null,

                            defaultContent: ' <a href="" class="btn btn-default btn-xs editor_remove"><i class="fa fa-trash"></i></a>'
                        },
                        { "data": "id" },
                        { "data": "descricao" }
                    ]
                });
            }
        });
    }

    function LimparCampos() {
        $("input[type=text]").each(function () {
            $(this).val("");
        });
        $("[id$=hdd_ACAO]").val("");
    }

    $("[id*=grdResultados]").on('click', 'a.editor_remove', function (e) {
        e.preventDefault();
        var row = $(this).closest("tr");
        $("[id$=hdd_ID]").val($(this).parent().parent()[0].cells[2].innerHTML);
        if (confirm("Deseja Mesmo Confirmar Está Operação?")) {
            $.ajax({
                type: "POST",
                url: "MotivoCancelamentoPericia.aspx/Delete",
                data: '{id: "' + $("[id$=hdd_ID]").val() + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data, e) {
                    Command: toastr["success"]("Exclusão realizada com sucesso!", "Atenção!");
                    Consultar();
                }
            });
        }
    });

    $("[id*=grdResultados]").on('click', 'a.editor_edit', function (e) {
        e.preventDefault();
        var row = $(this).closest("tr");
        $("[id$=hdd_ID]").val($(this).parent().parent()[0].cells[2].innerHTML);
        $("[id$=hdd_ACAO]").val("U");
        $("[id$=lModalTitulo]").text('Atualizar Motivo de cancelamento da perícia');
        $.ajax({
            type: "POST",
            url: "MotivoCancelamentoPericia.aspx/Editar",
            data: '{id: "' + $("[id$=hdd_ID]").val() + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data, e) {
                var parsed = $.parseJSON(data.d);
                $("[id$=txt_PROCESSO_LAUDO_PERICIA_MOTIVO_CANCELAMENTO_PERICIA_DESCRICAO]").val(parsed[0].descricao)
                $('.modal-backdrop').remove();
                $("#modalcadastro").show();
            }
        });
    });
}
$(document).ready(function () {
    BindControlEvents();
});