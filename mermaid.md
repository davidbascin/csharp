# Mermaid
See [Mermaid syntax](https://mermaid.js.org/intro/syntax-reference.html).

An example, inspired by a [cartoon](https://imgs.xkcd.com/comics/good_code.png) from https://xkcd.com/, ["How to write good code"](https://xkcd.com/844/).

```mermaid
---
config:
  look: classic
  theme: forest
---
flowchart TB
    Start([Start project]) --> RightOrFast{Do<br>things<br>right or do<br>them fast?};
    RightOrFast -- Fast --> CodeFast[Code Fast];
    CodeFast --> DoesItWork{Does<br>it work<br>yet ?};
    DoesItWork -- No --> CodeFast;
    DoesItWork -- "Almost, but it's<br>become a mess<br>of kludges and<br>spaghetti code." --> Throw[Throw it all out<br>and start over];
    Throw --> Start;
    RightOrFast -- Right --> CodeWell[Code Well];
    CodeWell --> DoneYet{Are<br>you done<br>yet ?};
    DoneYet -- No --> CodeWell;
    DoneYet -- "No, and the<br>requirements<br>have changed." --> Throw;
```

Shapes and lines

```mermaid
flowchart LR
    rect[processing] --- roundrect(processing);
    roundrect --> circle((on<br>page<br>connection));
    circle --- diamond{decision} -- Yes --> oval([start or end]);
    diamond -- No --> cylinder[(data store)] --> roundrect;
    roundrect --> A>asymmetric];
    A <--> rectrect[[predefined process]];
    rectrect <--> parallelogram[/input/output/];
    parallelogram ---> rect;
    A <--> rect;
```

## Visual Studio Code
Some hints for VSC use.

To preview on Windows/Linux CTRL+SHIFT+V; on MacOS CMD+SHIFT+P.

To view Mermaid diagrams, install VSC extension Markdown Preview Mermaid Support by bierner.
