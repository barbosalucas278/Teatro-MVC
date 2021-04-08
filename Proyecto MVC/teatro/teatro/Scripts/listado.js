$(document).ready(function () {
  const http = new consultaAPI();

  var isCreating = true;

  var urlObtener = window.location.origin + "/Integrantes/all";
  var urlCrear = window.location.origin + "/Integrantes/new";
  var urlObtenerPorId = window.location.origin + "/Integrantes/findbyid/";
  var urlEditar = window.location.origin + "/Integrantes/edit/";
  var urlDelete = window.location.origin + "/Integrantes/delete/";
  var urlVerificar = window.location.origin + "/Integrantes/verificar";

  var btnListar = $("#btnListar");
  var btnCrear = $("#btnCrear");
  var btnGuardar = $("#btnGuardar");
  var btnBorrar = $("#btnBorrar");

  var modalIntegrante = $("#modalIntegrante");
  var modaldelete = $("#modalDelete");

  var campoNombre = $("#nombre");
  var campoApellido = $("#apellido");
  var campoDni = $("#dni");
  var campoEdad = $("#edad");
  var campoTelefono = $("#telefono");
  var campoId = $("#integranteId");

  //------------SECTOR LISTAR INTEGRANTES---------------
  btnListar.on("click", CargaIntegrantes);

  function CargaIntegrantes() {
    http
      .get(urlObtener)
      .then((data) => ArmarTabla(data))
      .catch((error) => console.log(error));
  }

  //Se ejecuta la función para cargar por primera vez la tabla de integrantes
  CargaIntegrantes();

  function ArmarTabla(data) {
    let tBody = $("#tablaIntegrantes").find("tbody");
    tBody.html("");

    data.forEach((item) => {
      let fila = `<tr><td>${item.nombre}</td><td>${item.apellido}</td><td>${item.edad}</td><td>${item.telefono}</td><td>${item.dni}</td><td idIntegrante="${item.id}"><span class="badge badge-primary editar" style="cursor: pointer;">edit</span><span class="badge badge-danger eliminar" style="cursor: pointer;">delete</span></td></tr>`;
      tBody.append(fila);
    });
  }

  //------------SECTOR CREAR INTEGRANTE------------
  function VerificarDni(dni) {
    return new Promise(function (resolve, reject) {
      http
        .post(urlVerificar, dni)
        .then((data) => {
          resolve(data);
        })
        .catch((error) => reject(error));
    });
  }

  btnCrear.on("click", function () {
    isCreating = true;

    campoNombre.val("");
    campoApellido.val("");
    campoEdad.val("");
    campoTelefono.val("");
    campoDni.val("");

    modalIntegrante.find(".modal-header h4").html("Crear Integrante");
    $("div .form-group").removeClass("has-error");
    formModalCrear.valid();
    modalIntegrante.modal();
  });

  btnGuardar.on("click", function () {
    var integranteNuevo = {
      nombre: campoNombre.val(),
      apellido: campoApellido.val(),
      edad: campoEdad.val(),
      telefono: campoTelefono.val(),
      dni: campoDni.val(),
    };

    VerificarDni(integranteNuevo.dni)
      .then((response) => {
        let contenedor = campoDni.parent();
        if (response.existe == true) {
          if (contenedor.find("#dni-error").length == 0) {
            campoDni.closest(".form-group").addClass("has-error");
            contenedor.append(
              `<label class="help-block" id="dni-error" for="dni">El dni ya está registrado, ingrese otro</label>`
            );
          } else {
            console.log(contenedor.find("#dni-error"));
            campoDni.closest(".form-group").addClass("has-error");
            contenedor.find("#dni-error").attr("style", "");
            contenedor
              .find("#dni-error")
              .html("El dni ya está registrado, ingrese otro");
          }
        } else if (response.existe == false) {
          if (contenedor.find("#dni-error").length == 1) {
            campoDni.closest(".form-group").removeClass("has-error");
            contenedor.find("#dni-error").css("display", "none");
          }
        }
      })
      .catch((error) => console.log(error));
    if (isCreating) {
      if (formModalCrear.valid()) {
        http
          .post(urlCrear, integranteNuevo)
          .then((data) => {
            console.log(data);
            CargaIntegrantes();
            modalIntegrante.modal("hide");
          })
          .catch((error) => {
            console.log(error);
          });
      }
    } else {
      if (formModalCrear.valid()) {
        var cursoId = campoId.val();
        http
          .put(urlEditar + cursoId, integranteNuevo)
          .then((data) => {
            console.log(data);
            CargaIntegrantes();
            modalIntegrante.modal("hide");
          })
          .catch((error) => console.log(error));
      }
    }
    formModalCrear.valid();
  });
  //------------SECTOR MODIFICAR INTEGRANTE------------

  $(document).on("click", ".editar", function (e) {
    //Seteamos la flag en falso para que el modal que se muestre es el de modificar y no el de crear.
    isCreating = false;

    var integranteId = $(e.target).closest("td").attr("idIntegrante");
    //Guardamos el id del integrante que se encuentra en el atributo idIntegrante de la fila correspondiente al click
    campoId.val(integranteId);

    http
      .get(urlObtenerPorId + integranteId)
      .then((data) => {
        campoNombre.val(data.nombre);
        campoApellido.val(data.apellido);
        campoEdad.val(data.edad);
        campoTelefono.val(data.telefono);
        campoDni.val(data.dni);

        modalIntegrante.find(".modal-header h4").html("Modificar Integrante");
        $("div .form-group").removeClass("has-error");
        formModalCrear.valid();
        modalIntegrante.modal();
      })
      .catch((error) => console.log(error));
  });

  //------------SECTOR ELIMINAR INTEGRANTE------------
  $(document).on("click", ".eliminar", function (e) {
    console.log(e.target);
    var integranteId = $(e.target).closest("td").attr("idIntegrante");
    console.log(integranteId);
    //Guardamos el id del integrante que se encuentra en el atributo idIntegrante de la fila correspondiente al click
    campoId.val(integranteId);

    http
      .get(urlObtenerPorId + integranteId)
      .then((data) => {
        modaldelete
          .find(".modal-header h4")
          .html(`Eliminar a ${data.nombre} ${data.apellido}.`);
        modaldelete.modal();
      })
      .catch((error) => console.log(error));
  });

  btnBorrar.on("click", function () {
    http
      .delete(urlDelete + campoId.val())
      .then((data) => {
        console.log(data);
        CargaIntegrantes();
      })
      .catch((error) => console.log(error));
    modaldelete.modal("hide");
  });
});
