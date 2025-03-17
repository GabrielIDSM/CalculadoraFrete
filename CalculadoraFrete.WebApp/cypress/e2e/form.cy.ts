const cepsPrefeituras = [
  '01002020', // São Paulo - SP
  '20211110', // Rio de Janeiro - RJ
  '30130003', // Belo Horizonte - MG
  '40020000', // Salvador - BA
  '60055040', // Fortaleza - CE
  '90010170', // Porto Alegre - RS
  '80530000', // Curitiba - PR
  '50030903', // Recife - PE
  '69035000', // Manaus - AM
]

describe('Formulário', () => {
  it('Deve exibir cotações de frete', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('70075900') // Brasília - DF
    cy.get('input[name="Peso"]').type('0.8')
    cy.get('input[name="Largura"]').type('10')
    cy.get('input[name="Altura"]').type('10')
    cy.get('input[name="Comprimento"]').type('30')
    cy.get('input[name="Valor declarado"]').type('000')
    cy.get('form').submit()
    cy.get('.FreteSucesso', { timeout: 10000 }).should('be.visible')
  })

  it('Deve exibir mensagem de erro', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('70075900') // Brasília - DF
    cy.get('input[name="Peso"]').type('1000000') // Peso acima do permitido em qualquer modalidade
    cy.get('input[name="Largura"]').type('10')
    cy.get('input[name="Altura"]').type('10')
    cy.get('input[name="Comprimento"]').type('30')
    cy.get('input[name="Valor declarado"]').type('000')
    cy.get('form').submit()
    cy.get('.FreteErro', { timeout: 10000 }).should('be.visible')
  })

  it('Deve exibir mensagem de validação de campo (CEP inválido)', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('0') // CEP inválido
    cy.get('input[name="Peso"]').type('10')
    cy.get('input[name="Largura"]').type('10')
    cy.get('input[name="Altura"]').type('10')
    cy.get('input[name="Comprimento"]').type('30')
    cy.get('input[name="Valor declarado"]').type('000')
    cy.get('form').submit()
    cy.get('.Historico').should('not.exist')
    cy.get('.Campo span').should('be.visible')
  })

  it('Deve exibir mensagem de validação de campo (Peso inválido)', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('70075900') // Brasília - DF
    cy.get('input[name="Peso"]').type('0.')
    cy.get('input[name="Largura"]').type('10')
    cy.get('input[name="Altura"]').type('10')
    cy.get('input[name="Comprimento"]').type('30')
    cy.get('input[name="Valor declarado"]').type('000')
    cy.get('form').submit()
    cy.get('.Historico').should('not.exist')
    cy.get('.Campo span').should('be.visible')
  })

  it('Deve exibir mensagem de validação de campo (Largura inválida)', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('70075900') // Brasília - DF
    cy.get('input[name="Peso"]').type('10')
    cy.get('input[name="Largura"]').type('0')
    cy.get('input[name="Altura"]').type('10')
    cy.get('input[name="Comprimento"]').type('30')
    cy.get('input[name="Valor declarado"]').type('000')
    cy.get('form').submit()
    cy.get('.Historico').should('not.exist')
    cy.get('.Campo span').should('be.visible')
  })

  it('Deve exibir mensagem de validação de campo (Altura inválida)', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('70075900') // Brasília - DF
    cy.get('input[name="Peso"]').type('10')
    cy.get('input[name="Largura"]').type('10')
    cy.get('input[name="Altura"]').type('0')
    cy.get('input[name="Comprimento"]').type('30')
    cy.get('input[name="Valor declarado"]').type('000')
    cy.get('form').submit()
    cy.get('.Historico').should('not.exist')
    cy.get('.Campo span').should('be.visible')
  })

  it('Deve exibir mensagem de validação de campo (Comprimento inválido)', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('70075900') // Brasília - DF
    cy.get('input[name="Peso"]').type('10')
    cy.get('input[name="Largura"]').type('10')
    cy.get('input[name="Altura"]').type('10')
    cy.get('input[name="Comprimento"]').type('0')
    cy.get('input[name="Valor declarado"]').type('000')
    cy.get('form').submit()
    cy.get('.Historico').should('not.exist')
    cy.get('.Campo span').should('be.visible')
  })

  it('Deve exibir mensagem de validação de campo (Valor declarado inválido)', () => {
    const cepPrefeitura = cepsPrefeituras[Math.floor(Math.random() * cepsPrefeituras.length)]

    cy.visit('/')
    cy.get('input[name="CEP de origem"]').type(cepPrefeitura)
    cy.get('input[name="CEP de destino"]').type('70075900') // Brasília - DF
    cy.get('input[name="Peso"]').type('10')
    cy.get('input[name="Largura"]').type('10')
    cy.get('input[name="Altura"]').type('10')
    cy.get('input[name="Comprimento"]').type('0')
    cy.get('input[name="Valor declarado"]').clear()
    cy.get('form').submit()
    cy.get('.Historico').should('not.exist')
    cy.get('.Campo span').should('be.visible')
  })
})
