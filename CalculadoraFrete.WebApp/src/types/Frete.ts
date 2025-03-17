export interface ParametroEnvio {
  cepOrigem: string
  cepDestino: string
  peso: number
  largura: number
  altura: number
  comprimento: number
  valorDeclarado: number
}

export interface Endereco {
  cep: string
  uf: string
  estado: string
  localidade: string
  bairro: string
  logradouro: string
}

export interface CotacaoFrete {
  transportadora: string
  codigoTransportadora: string
  servico: string
  codigoServico: string
  prazoEntrega: number
  preco: number
}

export interface Resposta {
  parametroEnvio: ParametroEnvio
  origem?: Endereco
  destino?: Endereco
  cotacoes: CotacaoFrete[]
  sucesso: boolean
  mensagemErro?: string
  carregando?: boolean
}
