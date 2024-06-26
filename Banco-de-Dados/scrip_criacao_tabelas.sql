-- Cria banco de dados 
CREATE Database ProjetoIntegrador 
GO

USE ProjetoIntegrador
GO

--Cria Schema para tabelas 
CREATE Schema VersaoFinal
GO

-- Cria tabela produto
CREATE TABLE VersaoFinal.Produto(
    Id INT PRIMARY KEY IDENTITY(1,1), -- Coluna com o id do produto
    Nome Varchar(100),  -- Nome do pedido
    Descricao Varchar(200), -- Descrição do produto que é comprado 
    Preco Decimal(10,2),   -- Preço unitário do pedido 
    CaminhoImagem  Varchar(500), -- Caminho da foto do pedido
    PalavrasChave  Varchar(300)  -- Palavras chaves que aparecem na compra do pedido
);

-- Cria tabela de pedido
CREATE TABLE VersaoFinal.Pedido(
    Id INT PRIMARY KEY IDENTITY(1,1),            --Id do pedido 
    Total Decimal(10,2),        --Total de pedidos
    LoginUsuario Varchar(50),   --Login do usuário
    DataPedido DATETIME2            -- Data que foi feito o pedido   
);

-- Cria tabela de PedidoProduto
CREATE TABLE VersaoFinal.PedidoProduto(
    IdPedido int,               --Id do pedido solicitado
    IdProduto int,              --Id do Produto solicitado
    Preco Decimal(10,2),        --Preço do que foi gasto
    QuantidadeProduto Int       --Quantidade de itens 
    FOREIGN KEY (IdPedido) REFERENCES VersaoFinal.Pedido(Id),
    FOREIGN KEY (IdProduto) REFERENCES VersaoFinal.Produto(Id)
);
