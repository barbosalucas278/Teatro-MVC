$(document).ready(function () {
  //Configuracion de Moment.js para tener los dias de la semana en castellano
  moment.updateLocale("es", {
    weekdaysShort: ["Lun", "Mar", "Mie", "Jue", "Vie", "Sab", "Dom"],
    weekdaysMin: ["Lun", "Mar", "Mie", "Jue", "Vie", "Sab", "Dom"],
    weekdays: [
      "Lunes",
      "Martes",
      "Miecoles",
      "Jueves",
      "Vienes",
      "Sabado",
      "Domingo",
    ],
  });

  //Funciones Http
  const http = new consultaAPI();
  var isCreating = true;
  //Urls de la API
  const urlObtenerTodos = window.location.origin + "/Eventos/all";
  const urlObetenerById = window.location.origin + "/Eventos/findbyId/";
  const urlCrear = window.location.origin + "/Eventos/new";
  const urlObtenerOrquestas = window.location.origin + "/Orquestas/all";
  const urlOrquestaById = window.location.origin + "/Orquestas/findbyid/";
  const urlModificar = window.location.origin + "/Eventos/edit/";
  const urlEliminar = window.location.origin + "/Eventos/delete/";
  //Botones
  const btnListar = $("#btnListar");
  const btnCrear = $("#btnCrear");
  const btnGuardar = $("#btnGuardar");
  const btnSelect = $("#selectOrquesta");
  const btnBorrar = $("#btnBorrar");
  //Modales
  const modalCrear = $("#modalCrear");
  const modalDelete = $("#modalDelete");
  //Campos del formulario

  const campoObra = $("#obra");
  const campoFecha = $("#fecha");
  const campoOrquesta = $("#orquesta");
  const campoLocalidad = $("#localidad");
  const campoId = $("#eventoId");
  var localidadesArray;
  var idOrquestaSeleccionada;

  //------------SECTOR LISTAR EVENTOS---------------
  btnListar.on("click", CargarEventos);
  function CargarEventos() {
    http
      .get(urlObtenerTodos)
      .then((data) => ArmarTabla(data))
      .catch((error) => console.log(error));
  }
  CargarEventos();
  function ArmarTabla(eventos) {
    let tbody = $("#tablaEventos").find("tbody");
    tbody.html("");

    eventos.forEach((item) => {
      let dia = moment(item.dia);
      let fila = `<tr><td>${item.obra}</td><td>${dia.format(
        "dddd MM-YYYY"
      )}</td><td>${item.orquesta.nombre}</td><td>${
        item.orquesta.localidad
      }</td><td idEvento="${
        item.id
      }"><span class="badge badge-primary editar" style="cursor: pointer;">edit</span><span class="badge badge-danger eliminar" style="cursor: pointer;">delete</span></td></tr>`;
      tbody.append(fila);
    });
  }
  //------------SECTOR CREAR EVENTOS---------------
  function armarSelect(data) {
    btnSelect.html("<option selected>Seleccione una Orquesta</option>");
    let localidades = new Array();

    data.forEach((item) => {
      let option = `<option value="${item.id}" class="option">${item.nombre}</option>`;
      let localidad = {
        id: item.id,
        localidad: item.localidad,
      };
      localidades.push(localidad);
      btnSelect.append(option);
    });

    localidadesArray = localidades;
  }
  btnCrear.on("click", function () {
    isCreating = true;

    campoObra.val("");
    campoFecha.val("");
    campoLocalidad.val("");
    http
      .get(urlObtenerOrquestas)
      .then((data) => armarSelect(data))
      .catch((error) => console.log(error));

    $("div .form-group").removeClass("has-error");
    formModalCrear.valid();
    modalCrear.modal();
  });

  btnGuardar.on("click", function () {
    if (!isNaN(btnSelect.val())) {
      idOrquestaSeleccionada = btnSelect.val();
      var orquestaSeleccionada;
      http
        .get(urlOrquestaById + idOrquestaSeleccionada)
        .then(function (data) {
          orquestaSeleccionada = {
            id: data.id,
            nombre: data.nombre,
            localidad: data.localidad,
          };
          console.log(orquestaSeleccionada);
          var eventoNuevo = {
            obra: campoObra.val(),
            dia: campoFecha.val(),
            orquesta: {
              id: orquestaSeleccionada.id,
              nombre: orquestaSeleccionada.nombre,
              localidad: orquestaSeleccionada.localidad,
            },
          };
          if (isCreating) {
            if (formModalCrear.valid()) {
              http
                .post(urlCrear, eventoNuevo)
                .then((data) => {
                  console.log(data.id);
                  CargarEventos();
                  modalCrear.modal("hide");
                })
                .catch((error) => console.log(error));
            }
          } else {
            if (formModalCrear.valid()) {
              let eventoId = campoId.val();
              http
                .put(urlModificar + eventoId, eventoNuevo)
                .then((data) => {
                  console.log(data.id);
                  CargarEventos();
                  modalCrear.modal("hide");
                })
                .catch((error) => console.log(error));
            }
          }
        })
        .catch((error) => console.log(error));
    } else {
      formModalCrear.valid();
    }
  });
  //---------LOCALIDADES-------
  btnSelect.change("onchange", function () {
    //lo que hago ese es filtrar el array de localidades para buscar el unico que tenga el id de la localidad sleeccionada en el select.
    if (isNaN(btnSelect.val())) {
      campoLocalidad.val("");
    } else {
      let localidadSeleccionada = localidadesArray.filter(
        (x) => x.id == btnSelect.val()
      )[0];
      campoLocalidad.val(localidadSeleccionada.localidad);
    }
  });
  //------------SECTOR MODIFICAR EVENTOS---------------
  $(document).on("click", ".editar", function (e) {
    var eventoId = $(e.target).closest("td").attr("idEvento");
    campoId.val(eventoId);
    isCreating = false;
    http
      .get(urlObtenerOrquestas)
      .then((data) => armarSelect(data))
      .catch((error) => console.log(error));
    http
      .get(urlObetenerById + eventoId)
      .then((data) => {
        let dia = moment(data.dia);
        campoObra.val(data.obra);
        campoFecha.val(dia.format("YYYY-MM-DD"));
        btnSelect.val(data.orquesta.id);

        campoLocalidad.val(data.orquesta.localidad);

        modalCrear.find(".modal-header h4").html(`Modificar ${data.obra}`);
        //DUDA, PORQUE TENGO QUE UTILIZAR VALID() CADA VEZ QUE QUIERO QUE SE VALIDEN LOS CAMPOS?
        //HAY ALGUNA FORMA DE QUE SE HAGA AUTOMATICO?
        $("div .form-group").removeClass("has-error");
        formModalCrear.valid();
        modalCrear.modal();
      })
      .catch((error) => console.log(error));
  });
  //------------SECTOR ELIMINAR EVENTOS---------------
  $(document).on("click", ".eliminar", function (e) {
    var eventoId = $(e.target).closest("td").attr("idEvento");
    campoId.val(eventoId);

    http
      .get(urlObetenerById + eventoId)
      .then((data) => {
        let dia = moment(data.dia);
        modalDelete
          .find(".modal-body")
          .html(
            `<p> Obra: ${data.obra}</br>Dia: ${dia.format("dddd MM-YYYY")}`
          );
      })
      .catch((error) => console.log(error));
    modalDelete.modal();
  });
  btnBorrar.on("click", function () {
    http
      .delete(urlEliminar + campoId.val())
      .then((data) => {
        console.log(data);
        CargarEventos();
      })
      .catch((error) => console.log(error));
    modalDelete.modal("hide");
  });
});
