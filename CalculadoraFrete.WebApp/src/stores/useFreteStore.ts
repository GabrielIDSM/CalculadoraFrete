import { defineStore } from 'pinia'
import { ref } from 'vue'
import type { Resposta } from '../types/Frete'

export const useFreteStore = defineStore('frete', () => {
  const historico = ref<Resposta[]>([])

  const adicionarCotacao = (novaCotacao: Resposta) => {
    historico.value.unshift(novaCotacao)
  }

  return { historico, adicionarCotacao }
})
