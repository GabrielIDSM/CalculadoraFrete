<template>
  <section class="Historico" v-if="freteStore.historico.length">
    <div class="Conteudo">
      <div v-for="(resposta, index) in freteStore.historico" :key="index">
        <FreteSucesso v-if="resposta.sucesso && resposta.cotacoes.length" :resposta="resposta" />
        <FreteErro v-else :resposta="resposta" />
      </div>
    </div>
  </section>
</template>

<style scoped>
.Conteudo {
  padding: 50px 10px;
  border-top: solid 1px rgba(var(--van-dyke), 0.2);
  display: flex;
  flex-direction: column;
  gap: 30px;
}

@media (max-width: 980px) {
  .Conteudo {
    border-top: unset;
    background-color: rgba(var(--cinereous), 0.1);
  }
}
</style>

<script setup lang="ts">
import FreteErro from '@/components/cards/FreteErro.vue'
import FreteSucesso from '@/components/cards/FreteSucesso.vue'
import { useFreteStore } from '../stores/useFreteStore'

const freteStore = useFreteStore()
</script>
