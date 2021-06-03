class CrearCita {

    // token
    __RequestVerificationToken;
    // Componentes de pantalla
    afiliadoTipodentificacion;
    afiliadoNumeroIdentificacion;
    afiliadoNombres;
    afiliadoPrimerApellido;
    afiliadoSegundoApellido;
    afiliadoGenero;
    afiliadoRecidencia;
    tipoCita;
    sucursalCita;
    fechaCita;

    //componentes vacuna covid
    vacunaCovidBloque;
    btnConsultarEspacioCovid;
    agendaCovidContainer;
    datosSeleccionadosCovid;
    btnConfirmarCitaCovid;

    // Datos Consultados
    coreData;
    afiliadoConsultado;

    constructor() {
        this.__RequestVerificationToken = document.querySelector('[name="__RequestVerificationToken"]').value;
        let elements = document.querySelectorAll("[element]");
        for (let element of elements) {
            let name = element.getAttribute("element");
            if (this.hasOwnProperty(name)) {
                this[name] = element;
            }
        }
        this.afiliadoTipodentificacion.addEventListener('change', this.getDataAfiliado);
        this.afiliadoNumeroIdentificacion.addEventListener('change', this.getDataAfiliado);
        this.tipoCita.addEventListener('change', this.validarTipoCita );
        this.btnConsultarEspacioCovid.addEventListener('click', this.consutarDisponibleVacunacion);
        this.btnConfirmarCitaCovid.addEventListener('click', this.agendarCitaCovid);
    }

    getDataAfiliado() {
        showLoading();
        if (!view.afiliadoTipodentificacion.value || !view.afiliadoNumeroIdentificacion.value) {
            view.afiliadoConsultado = null;
            view.afiliadoNombres.value = '';
            view.afiliadoPrimerApellido.value = '';
            view.afiliadoSegundoApellido.value = '';
            view.afiliadoGenero.value = '';
            view.afiliadoRecidencia.value = '';
            hideLoading();
            return;
        }
        let params = {
            pIdTipoIdentificacion: view.afiliadoTipodentificacion.value,
            pNumeroIdentificacion: view.afiliadoNumeroIdentificacion.value,
        }
        let url = '/Citas/CrearCita/ValidarAfiliado?'+$.param(params);
        $.ajax(url)
        .done(function(data, textStatus, jqXHR ) {
            try { 
                if (data.success) {
                    view.afiliadoConsultado = data.objeto;
                    view.afiliadoNombres.value = view.afiliadoConsultado.PersonaF.Nombres;
                    view.afiliadoPrimerApellido.value = view.afiliadoConsultado.PersonaF.PrimerApellido;
                    view.afiliadoSegundoApellido.value = view.afiliadoConsultado.PersonaF.SegundoApellido;
                    view.afiliadoGenero.value = view.afiliadoConsultado.PersonaF.GeneroF.Nombre;
                    view.afiliadoRecidencia.value = `${view.afiliadoConsultado.RecidenciaDireccion}  ${view.afiliadoConsultado.RecidenciaBarrio} (${view.afiliadoConsultado.RecidenciaMunicipioF.Nombre} - ${view.afiliadoConsultado.RecidenciaMunicipioF.DepartamentoF.Nombre})`;
                    iziToast.success({ message: "Afiliado encontrado" });
                } else {
                    iziToast.warning({message: data.error});
                    view.limpiarAfiliado();
                }
            } catch (error) {
                iziToast.error({message: "Error de ejecución"});
                view.limpiarAfiliado();
            }
            hideLoading();
        })
        .fail(function(jqXHR, textStatus, errorThrown) {
            view.limpiarAfiliado();
            hideLoading();
        });
    }

    limpiarAfiliado() {
        view.afiliadoNombres.value = '';
        view.afiliadoPrimerApellido.value = '';
        view.afiliadoSegundoApellido.value = '';
        view.afiliadoGenero.value = '';
        view.afiliadoRecidencia.value = '';
    }

    validarTipoCita() {
        let vCodigo = this.options[this.selectedIndex].value;
        if (vCodigo == 'VAC_CO_VID') {
            view.vacunaCovidBloque.classList.remove('d-none');
        } else {
            view.vacunaCovidBloque.classList.add('d-none');
        }
    }

    consutarDisponibleVacunacion() {
        let url = '/Citas/CrearCita/BuscarDisponibilidadVacunacion';
        showLoading();
        let vIdTipoCita = view.tipoCita.options[view.tipoCita.selectedIndex].value;
        vIdTipoCita = view.coreData.TiposCitas.find(o => o.Codigo === vIdTipoCita).Id;
        let vIdSucursal = view.sucursalCita.options[view.sucursalCita.selectedIndex].value;
        let vFechaCitaString = view.fechaCita.value.split('-');
        if (vFechaCitaString && vFechaCitaString.length) {
            let vFechaCita = new Date(vFechaCitaString[0], vFechaCitaString[1] - 1, vFechaCitaString[2]);
            $.ajax({
                type: 'POST',
                url: url,
                data: {
                    __RequestVerificationToken: view.__RequestVerificationToken,
                    IdTipoCita : vIdTipoCita,
                    IdSucursal: vIdSucursal,
                    FechaCita: vFechaCita.toJSON()
                },
                dataType: 'json'
            })
            .done(function(data, textStatus, jqXHR ){
                if (data && data.success && data.consultorios && data.horas)
                {
                    view.generarAgendaVacunacion(data.consultorios, data.horas, data.celdas);
                }
                hideLoading();
            })
            .fail(function(jqXHR, textStatus, errorThrown) {
                hideLoading();
            });
        } else {
            iziToast.warning({message: 'Seleccione una fecha para la cita'});
            hideLoading();
        }
    }

    generarAgendaVacunacion(consultorios, horas, celdas) {
        view.agendaCovidContainer.innerHTML = "";
        let tabla = create('table');
        let cabecera = create('thead');
        let cuerpo = create('tbody');
        //agrego columna hora
        {
            let fila = create('tr');
            let columna = create('th');
            columna.innerText = 'Hora'
            columna.classList.add('hourColumn');
            $(fila).append(columna);
            $(cabecera).append(fila);
        }
        // agrego columnas por consultorios
        for (let consultorio of consultorios) {
            let fila = cabecera.querySelector('tr');
            let columna = create('th');
            columna.innerText = consultorio.Codigo;
            $(fila).append(columna);
        }
        $(tabla).append(cabecera);
        
        //agrego las celdas de las de horas 
        for (let hora of horas) {
            let fila = create('tr');
            let celda = create('th');
            celda.innerText = hora.Etiqueta;
            celda.classList.add('hourColumn');
            $(fila).append(celda);
            $(cuerpo).append(fila);
        }

        // recorro las celdas y las agrego
        for (let i = 0 ; i < celdas.length; i++) {
            let sceldas = celdas[i];
            for (let celda of sceldas) {
                let fila = cuerpo.querySelectorAll('tr')[i];
                let $celda = create('td');
                if (!celda.Bloqueada) {
                    $celda.classList.add('seleccionable');
                    $celda.seleccionada = false;
                    $celda.datos = celda;
                    $celda.addEventListener('click', view.seleccionarEspacioCovid);
                    $celda.addEventListener('mouseover', function(){
                        if (!this.seleccionada) this.innerHTML = this.datos.Hora.Etiqueta + ' - Consultorio ' + this.datos.Consultorio.Codigo;
                    });
                    $celda.addEventListener('mouseout', function(){
                        if (!this.seleccionada) this.innerHTML = ''
                    })
                } else {
                    $celda.classList.add('no-seleccionable');
                }
                $(fila).append($celda);
            }
        }

        $(tabla).append(cuerpo);
        $(tabla).addClass('table');

        $(view.agendaCovidContainer).append(tabla);
    }

    seleccionarEspacioCovid() {
        if (!this.seleccionada) {
            $('.seleccionada').click();
            this.seleccionada = true;
            this.classList.remove('seleccionable');
            this.classList.add('seleccionada');
            this.innerHTML = this.datos.Hora.Etiqueta + ' - Consultorio ' + this.datos.Consultorio.Codigo;
            view.datosSeleccionadosCovid = this.datos;
            view.btnConfirmarCitaCovid.classList.remove('d-none');
        } else {
            this.seleccionada = false;
            this.classList.add('seleccionable');
            this.classList.remove('seleccionada');
            this.innerHTML = '';
            view.datosSeleccionadosCovid = null;
            view.btnConfirmarCitaCovid.classList.add('d-none');
        }
    }

    agendarCitaCovid() {
        let valido = true;
        let url = '/Citas/CrearCita/RegistrarCitaVacunacion'
        if (!view.afiliadoConsultado || !view.afiliadoConsultado.Id) {
            iziToast.error({message: "Debe consultar un afiliado para agendar la cita"});
            valido = false;
        }
        if (!view.datosSeleccionadosCovid || !view.datosSeleccionadosCovid.Hora || !view.datosSeleccionadosCovid.Consultorio) {
            iziToast.error({message: "Debe seleccionar una hora especifica en un consultorio para agendar la cita"});
            valido = false;
        }
        if (valido) {
            $.ajax({
                type: 'POST',
                url: url,
                data: {
                    __RequestVerificationToken: view.__RequestVerificationToken,
                    IdHora : view.datosSeleccionadosCovid.Hora.Id,
                    Consultorio : view.datosSeleccionadosCovid.Consultorio,
                    Afiliado : view.afiliadoConsultado,
                },
                dataType: 'json'
            })
            .done(function(data, textStatus, jqXHR ){
                if (data && data.success)
                {
                    iziToast.show({
                        message: 'Cita Generada Satisfactoriamente',
                        position: 'center',
                        icon: 'ico-success',
                        timeout: 5000,
                        pauseOnHover: false,
                        overlay: true,
                        close: false,
                        onClosed: function () {window.location.reload();}
                    });
                } else{
                    data.errors.foreach(o => {
                        iziToast.error({message: o});
                    })
                }
                hideLoading();
            })
            .fail(function(jqXHR, textStatus, errorThrown) {
                iziToast.error({message: "Error en el servidor, intente de nuevo, si persiste, contacte al administrador del sistema"});
                hideLoading();
            });
        }
    }
}

this.view = new CrearCita();