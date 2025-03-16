<template>
  <section class="Historico" v-if="freteStore.historico.length">
    <div v-for="(resposta, index) in freteStore.historico" :key="index" class="Frete">
      <FreteSucesso v-if="resposta.sucesso && resposta.cotacoes.length" :resposta="resposta" />
      <FreteErro v-else :resposta="resposta" />
    </div>
  </section>
</template>

<script setup lang="ts">
import FreteErro from '@/components/cards/FreteErro.vue'
import FreteSucesso from '@/components/cards/FreteSucesso.vue'
import { useFreteStore } from '../stores/useFreteStore'

const freteStore = useFreteStore()
</script>
