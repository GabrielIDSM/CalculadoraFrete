describe('Página Inicial', () => {
  it('deve exibir o título correto', () => {
    cy.visit('/')
    cy.contains('h1', 'Bem-vindo à nossa Calculadora de Frete Grátis!')
  })
})
