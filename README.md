##hamiltonian-graphs-game

Jogo de quebra-cabeça desenvolvido em Unity baseado no clássico Icosian Game. O objetivo é desafiar o jogador a encontrar um Caminho Hamiltoniano em diferentes estruturas de grafos

Um Caminho Hamiltoniano é uma trajetória em um grafo que visita cada vértice exatamente uma vez. No contexto deste jogo:

    Você deve percorrer todos os pontos (nós) do gráfico.

    Não é permitido passar pelo mesmo nó duas vezes.

    O desafio termina quando todos os nós forem visitados (Caminho) ou quando você retorna ao ponto inicial após visitar todos (Ciclo).

🚀 Funcionalidades

    Representação de Grafos: Visualização clara de nós e arestas em um ambiente 3D/2D.

    Interatividade: Clique ou arraste para traçar o caminho em tempo real.

    Lógica de Validação: Sistema que impede movimentos inválidos e detecta a conclusão do desafio.

    Shaders Customizados: Uso de ShaderLab e HLSL para efeitos visuais nas conexões e estados dos nós.

🛠️ Tecnologias Utilizadas

    Engine: Unity 2022+ (ou versão correspondente)

    Linguagem: C#

    Gráficos: ShaderLab & HLSL (para feedback visual dinâmico)

🎮 Como Jogar

    Clone o repositório.

    Abra o projeto no Unity Hub.

    Carregue a cena principal em Assets/Scenes.

    Pressione Play e tente conectar todos os pontos sem repetir nenhum!
