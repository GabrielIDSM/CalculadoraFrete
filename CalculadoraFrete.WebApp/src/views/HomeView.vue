<template>
  <main>
    <BoasVindas />
    <Formulario @calcular-frete="calcularFrete" />
    <Historico />
  </main>
</template>

<script setup lang="ts">
import BoasVindas from '../components/BoasVindas.vue'
import Formulario from '../components/Formulario.vue'
import Historico from '../components/Historico.vue'
import { useFreteStore } from '../stores/useFreteStore'
import type { ParametroEnvio, Resposta } from '../types/Frete'
import axios from 'axios'

const freteStore = useFreteStore()

const calcularFrete = async (parametros: ParametroEnvio) => {
  try {
    const response = await axios.post<Resposta>(import.meta.env.VITE_API_URL, parametros)
    freteStore.adicionarCotacao(response.data)
  } catch (error) {
    console.error('Erro ao calcular frete: ', error)
  }
}
</script>
