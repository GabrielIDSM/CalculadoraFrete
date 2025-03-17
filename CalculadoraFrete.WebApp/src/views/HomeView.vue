<template>
  <BoasVindas />
  <Formulario @calcular-frete="calcularFrete" />
  <Historico />
</template>

<script setup lang="ts">
import BoasVindas from '@/components/BoasVindas.vue'
import Formulario from '@/components/Formulario.vue'
import Historico from '@/components/Historico.vue'
import { useFreteStore } from '@/stores/useFreteStore'
import type { ParametroEnvio, Resposta } from '@/types/Frete'
import axios from 'axios'

const freteStore = useFreteStore()

const calcularFrete = async (parametros: ParametroEnvio) => {
  try {
    const resposta = await axios.post<Resposta>(import.meta.env.VITE_API_URL, parametros)
    freteStore.adicionarCotacao(resposta.data)
  } catch (error) {
    const resposta: Resposta = {
      parametroEnvio: parametros,
      cotacoes: [],
      sucesso: false,
      mensagemErro: 'Erro interno',
    }
    freteStore.adicionarCotacao(resposta)
  } finally {
    const element = document.querySelector('.Historico')

    if (element) {
      element.scrollIntoView({ behavior: 'smooth', block: 'start' })
    }
  }
}
</script>
