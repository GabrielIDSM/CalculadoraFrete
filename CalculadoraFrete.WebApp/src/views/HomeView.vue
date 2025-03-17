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
  const respostaTemporaria: Resposta = {
    parametroEnvio: parametros,
    cotacoes: [],
    sucesso: false,
    carregando: true,
  }
  const historico = document.querySelector('.Historico')

  freteStore.adicionarCotacaoTemporaria(respostaTemporaria)
  if (historico) {
    historico.scrollIntoView({ behavior: 'smooth', block: 'start' })
  }

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
  }
}
</script>
