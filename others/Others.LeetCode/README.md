# Leet Code

O [*LeetCode*](https://leetcode.com/) é uma plataforma online de *coding challenges* usada **para praticar algoritmos e estruturas de dados**. É muito popular entre desenvolvedores que querem melhorar suas habilidades em programação e se preparar para entrevistas técnicas de empresas como Google, Microsoft e Amazon. Principais recursos são:

- ✅ Problemas categorizados por dificuldade (Fácil, Médio, Difícil)
- ✅ Suporte a várias linguagens de programação (C#, Java, Python, etc.)
- ✅ Mock interviews e testes cronometrados
- ✅ Discussões e soluções otimizadas da comunidade

🚀 Resumindo: É uma das melhores ferramentas para quem quer treinar algoritmos e estruturas de dados e se preparar para entrevistas técnicas.

## Lista de problemas e soluções

- [Binary Tree](./Solutions/BinaryTree.cs): é uma estrutura de dados hierárquica onde cada nó tem, no máximo, dois filhos: esquerdo e direito.

    - 🔹 Tipos principais:
        - ✅ Full Binary Tree → Cada nó tem 0 ou 2 filhos.
        - ✅ Complete Binary Tree → Todos os níveis são preenchidos da esquerda para a direita.
        - ✅ Perfect Binary Tree → Todos os nós internos têm dois filhos e todas as folhas estão no mesmo nível.
        - ✅ Balanced Binary Tree → Diferença de altura entre subárvores é mínima.

    - 🔹 Complexidades: Busca, Inserção, Remoção:
        
        ➡ O(log n) em árvores balanceadas (como AVL, Red-Black).
        
        ➡ O(n) no pior caso (árvore degenerada).

    🚀 Resumindo: Binary Tree é uma estrutura fundamental usada em algoritmos, armazenamento e buscas eficientes.

- [Breadth First Search](./Solutions/BreadthFirstSearch.cs): é um algoritmo de busca em largura usado para percorrer ou buscar elementos em grafos ou árvores. Ele explora todos os nós de um nível antes de passar para o próximo, garantindo a menor distância em grafos não ponderados.
    - ✅ Usa uma fila (queue) para armazenar os nós a serem explorados.
    - ✅ Garante o caminho mais curto em grafos não ponderados.
    - ✅ Funciona bem para encontrar a menor distância ou caminho mais curto.
    - 🔹 Complexidade: O(V + E) → Onde V é o número de vértices e E é o número de arestas.
    - 🚀 Resumindo: BFS é ideal para busca em largura e encontrar caminhos mínimos em grafos não ponderados.

- [Depth First Search](./Solutions/DepthFirstSearch.cs): Depth-First Search (DFS) é um algoritmo de busca em profundidade usado para percorrer ou buscar elementos em grafos e árvores. Ele explora o caminho mais fundo possível antes de retroceder (backtracking).
    - ✅ Usa uma pilha (stack) ou recursão para armazenar os nós a serem explorados.
    - ✅ Pode ser usado para detectar ciclos, encontrar componentes conectados e resolver problemas como labirintos.
    - ✅ Não garante o caminho mais curto, mas é eficiente para explorar todas as possibilidades.
    - 🔹 Complexidade: O(V + E) → Onde V é o número de vértices e E é o número de arestas.
    - 🚀 Resumindo: DFS é ideal para buscas profundas, caminhos alternativos e exploração completa de grafos.

- [Fibonacci Sequence](./Solutions/FibonacciSequence.cs): A sequência de Fibonacci é uma série de números onde cada termo é a soma dos dois anteriores, muito usada em algoritmos de otimização e modelagem matemática. Fórmula:

        F(n)=F(n−1)+F(n−2)

    🔹 Exemplo: 0, 1, 1, 2, 3, 5, 8, 13, 21, ... N

- [Invert Binary Tree](./Solutions/InvertBinaryTree.cs): é um problema clássico onde se troca os filhos esquerdo e direito de todos os nós de uma árvore binária.
    - 🔹 Métodos para inverter:
        - ✅ Recursivo: Troca os filhos em cada chamada recursiva.
        - ✅ Iterativo (BFS/DFS): Usa uma fila ou pilha para inverter nível por nível.
    - 🔹 Complexidade: O(n) → Onde n é o número de nós na árvore.
    - 🔹 Exemplo: https://assets.leetcode.com/uploads/2021/03/14/invert1-tree.jpg

- [Invert Linked List](./Solutions/InvertLinkedList.cs): consiste em reverter a ordem dos nós de uma lista ligada, fazendo com que o último nó se torne o primeiro e vice-versa.

    🔹 Exemplo:

        Antes: 1 → 2 → 3 → 4 → NULL
        Depois de inverter: 4 → 3 → 2 → 1 → NULL

- [Linked List](./Solutions/LinkedList.cs): é uma estrutura de dados linear onde os elementos (nós) são armazenados de forma não contígua na memória e conectados por ponteiros.
    - 🔹 Tipos:
        - ✅ Singly Linked List → Cada nó aponta para o próximo.
        - ✅ Doubly Linked List → Cada nó aponta para o próximo e o anterior.
        - ✅ Circular Linked List → O último nó aponta para o primeiro.

    - 🔹 Vantagens:
        - ✔ Inserção/remoção eficiente (O(1) se já tiver a referência do nó).
        - ✔ Uso dinâmico de memória, sem necessidade de redimensionamento.

    - 🔹 Desvantagens:
        - ❌ Acesso lento a elementos (O(n)).
        - ❌ Maior uso de memória devido aos ponteiros.

        🚀 Resumindo: LinkedList é uma estrutura flexível para manipulação eficiente de dados, mas com acesso sequencial mais lento que um array.

- [Word Search](./Solutions/WordSearch.cs): é um problema do LeetCode onde, dada uma matriz de caracteres e uma palavra, você deve verificar se a palavra pode ser formada seguindo caminhos adjacentes (cima, baixo, esquerda, direita) sem reutilizar a mesma célula.
    - 🔹 Abordagem comum:
        - ✅ Backtracking + DFS (Depth-First Search) → Explora todas as possibilidades recursivamente.
        - ✅ Marca células visitadas temporariamente para evitar repetições.
        - ✅ Complexidade: O(m * n * 4^L), onde m = linhas, n = colunas, L = comprimento da palavra.