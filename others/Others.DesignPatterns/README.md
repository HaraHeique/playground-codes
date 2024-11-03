## Factories

Um padrão criacional em que temos dois tipos principais:

- **Factory Method**: Esconde e encapsula a criação dos objetos concretos fornecendo uma interface comum e generalizada. O cliente externo não sabe como o objeto é criado, pois é abstrato para ele.
- **Abstract Factory**: É uma fábrica de Factory Methods, ou seja, fábrica de fábricas. Logo lidamos com uma fábrica de objetos com intuito de abstrair a criação de um cluster de objetos concretos e intercambiar entre eles.

**OBS.:** O conceito de abstração aqui refere-se ao ato de simplificar a complexidade do código ao ocultar os detalhes de implementação e focar nas funcionalidades essenciais de um componente ou sistema. 
A abstração permite que os desenvolvedores interajam com partes de um sistema sem precisar entender completamente como ele funciona internamente.

### Referências
- [Abstract Factory: Elemar Jr](https://www.youtube.com/watch?v=6SubIYR1HAY&t=1414s)
- [Factory Method: Elemar Jr](https://www.youtube.com/watch?v=xyLjrHfMXO4&t=2016s)

### Cenário:

    SHAPE FACTORIES:                        -- Here is the abstract factory
        REGULAR FACTORY:                    -- Here is the method factory
            - CIRCLE, SQUARE, RECTANGLE
        ROUNDED FACTORY:                    -- Here is the method factory
            - CIRCLE, SQUARE, RECTANGLE
        FILLED FACTORY:                     -- Here is the method factory
            - CIRCLE, SQUARE, RECTANGLE

DICA: Toda vez que tiver um cenário matricial de um conjunto de combinações como é mostrado abaixo, então pode ser usado abstract factory:

[abstract-factory-cenario](./docs/cenario-abstract-factory.webp)
