class CrearCita {
    // Componentes de pantalla
    afiliadoTipodentificacion;
    afiliadoNumeroIdentificacion;
    afiliadoNombres;
    afiliadoPrimerApellido;
    afiliadoSegundoApellido;
    afiliadoGenero;
    afiliadoRecidencia;

    // Json Cargado
    afiliadoConsultado;

    constructor() {
        let elements = document.querySelectorAll("[element]");
        for (let element of elements) {
            let name = element.getAttribute("element");
            if (this.hasOwnProperty(name)) {
                this[name] = element;
            }
        }
        this.afiliadoNumeroIdentificacion.addEventListener('change', function(){view.getDataAfiliado();});
    }

    getDataAfiliado() {
        showLoading();
        if (!view.afiliadoTipodentificacion.value || !view.afiliadoNumeroIdentificacion.value) {
            return;
        }
        let params = {
            pIdTipoIdentificacion: view.afiliadoTipodentificacion.value,
            pNumeroIdentificacion: view.afiliadoNumeroIdentificacion.value,
        }
        let url = '/Citas/CrearCita/ValidarAfiliado?'+$.param(params);
        $.ajax(url)
        .done(function(data, textStatus, jqXHR ){
            try {
                if (data.success) {
                    view.afiliadoConsultado = data.objeto;
                    view.afiliadoNombres.value = view.afiliadoConsultado.PersonaF.Nombres;
                    view.afiliadoPrimerApellido.value = view.afiliadoConsultado.PersonaF.PrimerApellido;
                    view.afiliadoSegundoApellido.value = view.afiliadoConsultado.PersonaF.SegundoApellido;
                    view.afiliadoGenero.value = view.afiliadoConsultado.PersonaF.GeneroF.Nombre;
                    view.afiliadoRecidencia.value = `${view.afiliadoConsultado.RecidenciaDireccion}  ${view.afiliadoConsultado.RecidenciaBarrio} (${view.afiliadoConsultado.RecidenciaMunicipioF.Nombre} - ${view.afiliadoConsultado.RecidenciaMunicipioF.DepartamentoF.Nombre})`;
                    iziToast.success({message: "Afiliado encontrado"});
                } else {
                    iziToast.warning({message: data.error});
                    view.limpiarVista();
                }
            } catch (error) {
                iziToast.error({message: "Error de ejecución"});
                view.limpiarVista();
            }
            hideLoading();
        })
        .fail(function(jqXHR, textStatus, errorThrown) {
            view.limpiarVista();
            hideLoading();
        });
    }

    limpiarVista() {
        view.afiliadoNombres.value = '';
        view.afiliadoPrimerApellido.value = '';
        view.afiliadoSegundoApellido.value = '';
        view.afiliadoGenero.value = '';
        view.afiliadoRecidencia.value = '';
    }
}

this.view = new CrearCita();