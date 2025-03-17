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
          <font-awesome-icon icon="fa-solid fa-map-location-dot" />
        </div>
        <div class="Informacoes">
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

<style scoped>
.Frete {
  padding: 8px;
  border-radius: 8px;
  border: solid 1px rgba(var(--van-dyke), 0.6);
  background-color: rgba(var(--off-white), 1);
  display: flex;
  flex-direction: column;
  gap: 8px;
}

.Cabecalho {
  display: flex;
  gap: 10px;
}

.Pacote,
.Enderecos {
  height: 48px;
  display: flex;
}

.Icone {
  width: 48px;
  height: 48px;
  position: relative;
}

.Icone svg {
  width: auto;
  height: 24px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  color: rgba(var(--van-dyke), 1);
}

.Informacoes {
  display: flex;
  flex-direction: column;
  flex: 1;
}

.Informacoes p {
  margin: 0;
  font-size: 16px;
  font-weight: 500;
  line-height: 24px;
}

.Dimensoes {
  height: 24px;
  display: flex;
  gap: 5px;
  align-items: center;
}

.Peso {
  height: 24px;
}

.EnderecoOrigem {
  display: flex;
  gap: 5px;
  align-items: center;
}

.Cotacoes {
  width: 100%;
  border-collapse: separate;
  border-spacing: 0;
}

.Cotacoes td {
  height: 35px;
}

.Cotacoes td:nth-child(1) {
  padding-left: 10px;
}

.Cotacoes td:nth-child(3) {
  padding-right: 10px;
}

.Cotacoes tr:nth-child(even) td {
  background-color: rgba(var(--cinereous), 0.05);
}

.Cotacoes tr:nth-child(odd) td {
  background-color: rgba(var(--cinereous), 0.1);
}

.Cotacoes thead tr {
  width: 100%;
  height: 35px;
}

.Cotacoes thead th {
  font-weight: 800;
  font-size: 16px;
  line-height: 24px;
  color: rgba(var(--van-dyke), 1);
  border-top: solid 1px rgba(var(--van-dyke), 0.5);
  border-bottom: solid 1px rgba(var(--van-dyke), 0.5);
  background-color: rgba(var(--cinereous), 0.2);
}

.Cotacoes thead th:nth-child(1) {
  padding-left: 10px;
  width: 30%;
  border-radius: 12px 0 0 12px;
  border-left: solid 1px rgba(var(--van-dyke), 0.5);
}

.Cotacoes thead th:nth-child(2) {
  width: 40%;
}

.Cotacoes thead th:nth-child(3) {
  padding-right: 10px;
  width: 30%;
  border-radius: 0 12px 12px 0;
  border-right: solid 1px rgba(var(--van-dyke), 0.5);
}

.Cotacoes tbody td {
  color: rgba(var(--van-dyke), 1);
}

@media (max-width: 980px) {
  .Frete {
    gap: 20px;
  }

  .Pacote,
  .Enderecos {
    min-height: 48px;
    height: unset;
    align-items: center;
  }

  .Pacote .Informacoes {
    flex: unset;
  }

  .Enderecos .Icone {
    display: none;
  }

  .Enderecos .Informacoes {
    gap: 5px;
    text-align: center;
  }

  .EnderecoOrigem {
    flex-direction: column;
    gap: 5px;
  }

  .Cotacoes {
    text-align: center;
  }

  .Cabecalho {
    flex-direction: column;
    gap: 20px;
  }
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
