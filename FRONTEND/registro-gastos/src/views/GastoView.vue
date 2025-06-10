<template>
  <div class="main-content">
  <h2>Registrar Gasto</h2>
  <Form :validation-schema="schema" @submit="enviarDatosApi" id="formulario-carga">
    <label>
      Monto:
      <Field v-model="gasto.monto" type="text" name="monto" />
    </label>
    <ErrorMessage name="monto" />

    <br />

    <label>
      Descripción:
      <Field v-model="gasto.descripcion" type="text" name="descripcion" />
    </label>
    <ErrorMessage name="descripcion" />

    <br />

    <label>
      Fecha:
      <Field v-model="gasto.fecha" type="date" name="fecha" />
    </label>
    <ErrorMessage name="fecha" />

    <br />

    <label>
      Nombre del Comercio:
      <Field v-model="gasto.nombreComercio" type="text" name="nombreComercio" />
    </label>
    <ErrorMessage name="nombreComercio" />

    <br />

    <input type="submit" value="Guardar" />

    <router-link to="/">
      <button>Volver</button>
    </router-link>
  </Form>
  </div>
</template>

<script setup>
import { ref } from 'vue'
import { Form, Field, ErrorMessage } from 'vee-validate'
import * as yup from 'yup'

const schema = yup.object({
  monto: yup.number().typeError('Debe ser un número').positive('Debe ser mayor que cero').required('El monto es obligatorio'),
  descripcion: yup.string().min(3, 'El mínimo de caracteres es 3').max(250, 'El máximo de caracteres es 250').required('La descripción es obligatoria'),
  fecha: yup.date().typeError('La fecha no es válida').max(new Date(), 'No se permite una fecha futura').required('La fecha es obligatoria'),
  nombreComercio: yup.string().min(1, 'El nombre del comercio no puede estar vacío').max(250, 'El máximo de caracteres es 250').required('El nombre del comercio es obligatorio')
})

let gasto = ref({
  monto: '',
  descripcion: '',
  fecha: '',
  nombreComercio: ''
})


async function enviarDatosApi() {
  const response = await fetch('https://localhost:7091/api/Gasto', {
    method: 'POST',
    body: JSON.stringify(gasto.value),
    headers: {
      'Content-Type': 'application/json'
    }
  })

  if (response.ok) {
    alert('Gasto guardado correctamente');
    gasto.value = {
        monto: '',
        descripcion: '',
        fecha: '',
        nombreComercio: ''
      }
  } else {
    alert('Error al guardar el gasto')
  }
}
</script>

<style scoped></style>
