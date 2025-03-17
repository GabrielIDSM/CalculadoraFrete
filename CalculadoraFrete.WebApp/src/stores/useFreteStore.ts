import { defineStore } from 'pinia'
import { ref } from 'vue'
import type { Resposta } from '../types/Frete'

export const useFreteStore = defineStore('frete', () => {
  const historico = ref<Resposta[]>([])

  const adicionarCotacaoTemporaria = (cotacaoTemporaria: Resposta) => {
    historico.value.unshift(cotacaoTemporaria)
  }

  const adicionarCotacao = (novaCotacao: Resposta) => {
    historico.value[0] = novaCotacao
  }

  return { historico, adicionarCotacao, adicionarCotacaoTemporaria }
})
