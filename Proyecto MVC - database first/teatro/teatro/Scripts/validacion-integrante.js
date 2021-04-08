const formModalCrear = $("#modalForm");
var urlObtener = window.location.origin + "/Integrantes/telefonos/";
var urlVerificar = window.location.origin + "/Integrantes/verificar";
const http = new consultaAPI();

console.log(formModalCrear);
$(document).ready(function () {
  $.validator.setDefaults({
    errorClass: "help-block",
    highlight: function (element) {
      $(element).closest(".form-group").addClass("has-error");
    },
    unhighlight: function (element) {
      $(element).closest(".form-group").removeClass("has-error");
    },
  });

  $.validator.addMethod(
    "nowhitespace",
    function (value, element) {
      return this.optional(element) || /^\S+$/i.test(value);
    },
    "NO debe contener espacios"
  );

  formModalCrear.validate({
    rules: {
      nombre: {
        required: true,
        nowhitespace: true,
      },
      apellido: {
        required: true,
        nowhitespace: true,
      },
      edad: {
        required: true,
        digits: true,
        range: [18, 100],
      },
      telefono: {
        required: true,
        minlength: 10,
        maxlength: 10,
      },
      dni: {
        required: true,
        minlength: 8,
        maxlength: 10,
      },
    },
    messages: {
      nombre: {
        required: "Debe ingresar un nombre",
      },
      apellido: {
        required: "Debe ingresar un apellido",
      },
      edad: {
        required: "Debe ingresar una edad",
        range: "Debe ingresar una edad valida, mayor de 18 años",
        digits: "Debe seleccionar una orquesta",
      },
      telefono: {
        required: "Debe ingresar un telefono",
        minlength: "Debe tener 10 caracteres minimo",
        maxlength: "Debe tener 10 caracteres maximo",
      },
      dni: {
        required: "Debe ingresar un dni",
        minlength: "Debe tener 8 caracteres minimo",
        maxlength: "Debe tener 10 caracteres maximo",
      },
    },
  });
});
