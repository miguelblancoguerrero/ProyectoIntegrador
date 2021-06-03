$(document).ready(function () {
 
    $("input[numbermask]").keypress(function (e) {       
        if (e.which != 8 && e.which != 0 && (e.which < 48 || e.which > 57)) {
            return false;
        }
    });
});

/** Metodo que genere elementos html para manipular por DOM la pantalla
 * @param name nombre del elemento DOM (etiqueta HTML) a generar
 * @returns Elemento DOM  correspondiente al nombre pasado como parametro
 */
function create(name) {
    let element = document.createElement(name);
    return element;
}