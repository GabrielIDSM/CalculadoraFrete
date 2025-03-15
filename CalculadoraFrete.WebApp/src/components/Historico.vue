<template>
  <section class="Historico" v-if="freteStore.historico.length">
    <div v-for="(resposta, index) in freteStore.historico" :key="index" class="Frete">
      <h3>Cotação para envio de {{ resposta.parametroEnvio?.peso }}kg</h3>
      <p>
        De: {{ resposta.parametroEnvio?.cepOrigem }} | Para:
        {{ resposta.parametroEnvio?.cepDestino }}
      </p>

      <div v-for="cotacao in resposta.cotacoes" :key="cotacao.codigoServico" class="Cotacao">
        <strong>{{ cotacao.transportadora }} - {{ cotacao.servico }}</strong>
        <p>
          Prazo: {{ cotacao.prazoEntrega }} dias | Preço: R$
          {{ cotacao.preco?.toFixed(2) || '0.00' }}
        </p>
      </div>
    </div>
  </section>
</template>

<script setup lang="ts">
import { useFreteStore } from '../stores/useFreteStore'
const freteStore = useFreteStore()
</script>
