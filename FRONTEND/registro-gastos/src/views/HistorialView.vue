
<template>
   <div class="main-content">
    <h2>Historial de Gastos</h2>
    <table>
      <thead>
        <tr>
          <th>Monto</th>
          <th>Descripción</th>
          <th>Fecha</th>
          <th>Nombre del Comercio</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="(gasto, index) in historialGastos" :key="index">
          <td>${{ gasto.monto }}</td>
          <td>{{ gasto.descripcion }}</td>
          <td>{{ formatoFecha(gasto.fecha) }}</td>
          <td>{{ gasto.nombreComercio }}</td>
        </tr>
      </tbody>
    </table>

    <div class="home">
      <router-link to="/">
        <button>Volver</button>
      </router-link>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue'
let historialGastos = ref([]);

async function cargarDatosApi() {
  try {
    let respuesta = await fetch('https://localhost:7091/api/Gasto');
    historialGastos.value = await respuesta.json();
  } catch (error) {
    console.error('Error al cargar los gastos:', error);
  }
}

function formatoFecha(fechaString) {
  const fecha = new Date(fechaString);
  return fecha.toLocaleDateString('es-AR');
}

cargarDatosApi();
</script>

<style></style>
