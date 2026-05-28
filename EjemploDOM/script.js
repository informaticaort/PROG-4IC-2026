  // Referencias al DOM
  const inputNombre  = document.getElementById("nombreAlumno");
  const inputTitulo  = document.getElementById("titulo");
  const inputDias    = document.getElementById("diasPrestamo");
  const selectEstado = document.getElementById("estado");
  const divResumen   = document.getElementById("resumenDias");
  const divResultado = document.getElementById("resultado");
  const fbTitulo = document.getElementById("fb-titulo");
  const fbNombre = document.getElementById("fb-nombre");
  const fbDias = document.getElementById("fb-dias");
  const fbEstado = document.getElementById("fb-estado");
 
  // Se ejecuta cada vez que el usuario escribe en el campo días
  function actualizarResumen() {
    const dias = parseInt(inputDias.value);
    if (!isNaN(dias) && dias >= 1 && dias <= 14) {
      const hoy        = new Date();
      const devolucion = new Date(hoy);
      devolucion.setDate(hoy.getDate() + dias);
      divResumen.innerHTML = "Devolver el <strong>" + devolucion + "</strong>";
    } else {
      divResumen.innerHTML = "— completá los días para ver la fecha —";
    }
  }
 
  function registrarPrestamo() {
 
    const nombre = inputNombre.value;
    const titulo = inputTitulo.value;
    const dias   = parseInt(inputDias.value);
    const estado = selectEstado.value;
 
    const errores = [];
    limpiarFeedbacks();
 
    // Validación 1 — nombre
    if (nombre === "") {
      errores.push("El nombre del alumno es obligatorio.");
      mostrarError("fb-nombre", "Campo obligatorio");
    } else {
      mostrarOk("fb-nombre", "✓ OK");
    }
 
    // Validación 2 — título
    if (titulo === "") {
      errores.push("El título del libro es obligatorio.");
      mostrarError("fb-titulo", "Campo obligatorio");
    } else {
      mostrarOk("fb-titulo", "✓ OK");
    }
 
    // Validación 3 — días
    if (isNaN(dias) || dias < 1 || dias > 14) {
      errores.push("Los días deben ser entre 1 y 14.");
      mostrarError("fb-dias", "Ingresá un valor entre 1 y 14");
    } else {
      mostrarOk("fb-dias", "✓ OK");
    }
 
    // Validación 4 — estado
    if (estado === "") {
      errores.push("Seleccioná el estado del alumno.");
      mostrarError("fb-estado", "Estado requerido");
    } else if (estado === "deudor") {
      errores.push("El alumno tiene un préstamo sin devolver.");
      mostrarError("fb-estado", "No puede pedir otro préstamo");
    } else if (estado === "suspendido") {
      errores.push("El alumno está suspendido.");
      mostrarError("fb-estado", "No puede realizar préstamos");
    } else {
      mostrarOk("fb-estado", "✓ Apto para préstamo");
    }
 
    // Resultado final
 
    if (errores.length > 0) {
      divResultado.style.color  = "red";
      divResultado.style.border = "1px solid red";
      divResultado.style.padding = "8px";
      divResultado.innerHTML = "<strong>No se pudo registrar:</strong><br>"
                             + errores.join("<br>");
    } else {
      divResultado.style.color  = "green";
      divResultado.style.border = "1px solid green";
      divResultado.style.padding = "8px";
      divResultado.innerHTML = "<strong>Préstamo registrado</strong><br>"
                             + "Alumno: " + nombre + "<br>"
                             + "Libro: "  + titulo + "<br>"
                             + "Días: "   + dias
                             + " — " + divResumen.innerText;
    }
  }
 
  // Helpers
  function mostrarError(id, msg) {
    const el = document.getElementById(id);
    el.innerHTML = msg;
    el.style.color = "red";
  }
 
  function mostrarOk(id, msg) {
    const el = document.getElementById(id);
    el.innerHTML = msg;
    el.style.color = "green";
  }
 
  function limpiarFeedbacks() {
   fbTitulo.innerHTML = "";
   fbNombre.innerHTML = "";
   fbDias.innerHTML = "";
   fbEstado.innerHTML = "";
  }
 
  function limpiarFormulario() {
    inputNombre.value  = "";
    inputTitulo.value  = "";
    inputDias.value    = "";
    selectEstado.value = "";
    divResumen.innerHTML      = "— completá los días para ver la fecha —";
    divResultado.innerHTML     = "";
    limpiarFeedbacks();
  }