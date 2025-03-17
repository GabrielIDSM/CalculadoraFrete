describe('Página Inicial', () => {
  it('Deve exibir o título', () => {
    cy.visit('/')
    cy.contains('h1', 'Bem-vindo à nossa Calculadora de Frete Grátis!')
  })
  it('Deve exibir o formulário', () => {
    cy.visit('/')
    cy.get('.Formulario').should('exist')
  })
})
