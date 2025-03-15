export interface ParametroEnvio {
  CEPOrigem: string
  CEPDestino: string
  Peso: number
  Largura: number
  Altura: number
  Comprimento: number
  ValorDeclarado: number
}

export interface CotacaoFrete {
  Transportadora: string
  CodigoTransportadora: string
  Servico: string
  CodigoServico: string
  PrazoEntrega: number
  Preco: number
}

export interface Resposta {
  ParametroEnvio: ParametroEnvio
  Cotacoes: CotacaoFrete[]
  Sucesso: boolean
  MensagemErro?: string
}
