export interface ParametroEnvio {
  cepOrigem: string
  cepDestino: string
  peso: number
  largura: number
  altura: number
  comprimento: number
  valorDeclarado: number
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
  cotacoes: CotacaoFrete[]
  sucesso: boolean
  mensagemErro?: string
}
