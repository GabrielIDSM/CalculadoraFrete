<template>
  <section class="Frete FreteErro">
    <h2>Infelizmente, não foi possível concluir sua solicitação</h2>
    <p v-if="props.resposta.sucesso">
      Erro: Não existem cotações disponíveis para os endereços fornecidos
    </p>
    <p v-else>Erro: {{ props.resposta.mensagemErro }}</p>
  </section>
</template>

<script setup lang="ts">
import type { PropType } from 'vue'
import type { Resposta } from '@/types/Frete'

const props = defineProps({
  resposta: {
    type: Object as PropType<Resposta>,
    required: true,
  },
  index: Number,
})
</script>
