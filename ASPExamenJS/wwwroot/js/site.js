class Persona {
    constructor(id, nombre, apellidos, idDepartamento) {
        this.id = id;
        this.nombre = nombre;
        this.apellidos = apellidos;
        this.idDepartamento = idDepartamento;
    }
}

const URL = "http://localhost:5082/API/Persona/";

window.onload = getAllPersonas();

function getAllPersonas() {
    var client = new XMLHttpRequest();
    client.open("GET", URL);
    client.onreadystatechange = () => {
        if (client.readyState == 4 && client.status == 200) {
            var personas = JSON.parse(client.responseText);
            var tbody = document.getElementById("tbody");
            tbody.innerHTML = "";
            for (var i = 0; i < personas.length; i++) {
                tbody.innerHTML += `
                    <tr>
                        <td>${personas[i].id}</td>
                        <td>${personas[i].nombre}</td>
                        <td>${personas[i].apellidos}</td>
                        <td>${personas[i].idDepartamento}</td>
                        <td>
                            <button onclick="editPersona(event)">Editar</button>
                            <button onclick="deletePersona(${personas[i].id}, event)">Delete</button>
                        </td>
                    </tr>
                `;

            }
        }
    }
    client.send();
}

function agregarPersona() {
    var persona = new Persona();
    persona.id = document.getElementById("idPersona").value;
    persona.nombre = document.getElementById("nombrePersona").value;
    persona.apellidos = document.getElementById("apellidosPersona").value;
    persona.idDepartamento = document.getElementById("idDepartamentoPersona").value;

    var cliente = new XMLHttpRequest();
    cliente.open("POST", URL);
    cliente.onreadystatechange = () => {
        if (cliente.readyState == 4 && cliente.status == 200) {
            alert("Se ha agregado correctamente");
            // borramos los formularios
            document.getElementById("idPersona").value = "";
            document.getElementById("nombrePersona").value = "";
            document.getElementById("apellidosPersona").value = "";
            document.getElementById("idDepartamentoPersona").value = "";

            getAllPersonas();
        }
    }
    cliente.setRequestHeader("Content-Type", "application/json");
    cliente.send(JSON.stringify(persona));
}

function editPersona(event) {
    const fila = event.target.closest('tr');
    const tds = fila.querySelectorAll('td');
    console.log(tds);

    const editDiv = document.createElement('tr');
    editDiv.id = "editdiv";
    editDiv.innerHTML = `
        <td><input type="hidden" id="editid" value="${tds[0].outerText}" /></td>
        <td><input type="text" value="${tds[1].outerText}" id="editnombre" /></td>
        <td><input type="text" value="${tds[2].outerText}" id="editapellidos" /></td>
        <td><input type="number" value="${tds[3].outerText}" id="iddepartamento"/></td>
        <td><button onclick="editFr()">Confirmar</button></td>
    `;

    fila.insertAdjacentElement('afterend', editDiv);
}

function editFr() {
    var persona = new Persona();
    persona.id = document.getElementById("editid").value;
    persona.nombre = document.getElementById("editnombre").value;
    persona.apellidos = document.getElementById("editapellidos").value;
    persona.idDepartamento = document.getElementById("iddepartamento").value;

    console.log(persona);

    var client = new XMLHttpRequest();
    client.open("PUT", URL + `${persona.id}`);
    client.onreadystatechange = () => {
        if (client.readyState == 4 && client.status == 200) {
            alert("Se ha modificado correctamente.");
            document.getElementById("editdiv").innerHTML = "";
            getAllPersonas();
        }
    }
    client.setRequestHeader("Content-Type", "application/json");
    client.send(JSON.stringify(persona));
}


function deletePersona(id, event) {
    if (confirm("¿Estás seguro de que quieres borrar esta persona?")) {
        var client = new XMLHttpRequest();
        client.open("DELETE", URL + `${id}`)
        client.onreadystatechange = () => {
            if (client.readyState == 4 && client.status == 200) {
                alert(client.responseText);
                const fila = event.target.closest('tr');
                fila.remove();
            }
        }
        client.send();
    }
}