// Form Modales
const formModalCrear = $("#modalForm");
console.log(formModalCrear);
$(function () {
  $.validator.setDefaults({
    errorClass: "help-block",
    highlight: function (element) {
      $(element).closest(".form-group").addClass("has-error");
    },
    unhighlight: function (element) {
      $(element).closest(".form-group").removeClass("has-error");
    },
  });
  formModalCrear.validate({
    rules: {
      obra: {
        required: true,
      },
      fecha: {
        required: true,
        date: true,
        min: "1900-01-01",
        max: moment().add(1, "year").format("YYYY-MM-DD"),
      },
      selectOrquesta: {
        digits: true,
      },
    },
    messages: {
      obra: {
        required: "Debe ingresar un nombre",
      },
      fecha: {
        required: "Debe ingresar una fecha",
        date: "Ingrese una fecha válida",
        min: "Debe ingresar una fecha mayor a {0}",
        max: "Debe ingresar una fecha menor a {0}",
      },
      selectOrquesta: {
        digits: "Debe seleccionar una orquesta",
      },
    },
  });
});
