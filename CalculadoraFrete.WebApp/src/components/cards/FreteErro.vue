<template>
  <section class="Frete FreteErro">
    <h2>Infelizmente, não foi possível concluir sua solicitação</h2>
    <p v-if="props.resposta.sucesso">
      Não existem cotações disponíveis para os endereços fornecidos
    </p>
    <p v-else>{{ props.resposta.mensagemErro }}</p>
  </section>
</template>

<style scoped>
.Frete {
  padding: 8px;
  border-radius: 8px;
  border: solid 1px rgba(var(--cor-status), 0.6);
  background-color: rgba(var(--cor-status), 0.05);
}

h2 {
  margin: 0;
  font-size: 16px;
  font-weight: 500;
  line-height: 24px;
  color: rgba(var(--cor-status), 1);
}

p {
  margin: 0;
  font-size: 14px;
  font-weight: 400;
  line-height: 20px;
}
</style>

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
