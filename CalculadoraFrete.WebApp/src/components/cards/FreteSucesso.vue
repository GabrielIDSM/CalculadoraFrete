<template>
  <section class="Frete FreteSucesso">
    <div class="Cabecalho">
      <div class="Pacote">
        <div class="Icone">
          <font-awesome-icon icon="fa-solid fa-box-open" />
        </div>
        <div class="Informacoes">
          <div class="Dimensoes">
            <p>{{ props.resposta.parametroEnvio.largura }}</p>
            <font-awesome-icon icon="fa-solid fa-xmark" />
            <p>{{ props.resposta.parametroEnvio.altura }}</p>
            <font-awesome-icon icon="fa-solid fa-xmark" />
            <p>{{ props.resposta.parametroEnvio.comprimento }} cm</p>
          </div>
          <div class="Peso">
            <p>{{ props.resposta.parametroEnvio.peso }} kg</p>
          </div>
        </div>
      </div>
      <div class="Enderecos">
        <div class="Icone">
          <font-awesome-icon icon="fa-solid fa-location-dot" />
        </div>
        <div class="Infomacoes">
          <div class="Endereco EnderecoOrigem">
            <p>
              {{ props.resposta.origem.bairro }}, {{ props.resposta.origem.localidade }},
              {{ props.resposta.origem.estado }} ({{ props.resposta.origem.uf }})
            </p>
            <font-awesome-icon icon="fa-solid fa-arrow-right" />
          </div>
          <div class="Endereco">
            <p>
              {{ props.resposta.destino.bairro }}, {{ props.resposta.destino.localidade }},
              {{ props.resposta.destino.estado }} ({{ props.resposta.destino.uf }})
            </p>
          </div>
        </div>
      </div>
    </div>
    <table class="Cotacoes">
      <thead>
        <tr>
          <th>Serviço</th>
          <th>Estimativa de entrega</th>
          <th>Preço</th>
        </tr>
      </thead>
      <tbody>
        <tr class="Cotacao" v-for="cotacao in props.resposta.cotacoes" :key="cotacao.codigoServico">
          <td>{{ cotacao.servico }} ({{ cotacao.transportadora }})</td>
          <td>{{ cotacao.prazoEntrega }} dias</td>
          <td>R$ {{ cotacao.preco.toFixed(2).replace('.', ',') }}</td>
        </tr>
      </tbody>
    </table>
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
