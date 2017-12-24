# NetworkingBasics
Wollte ein kleines Extra-Projekt aufsetzen, um das Networking besser zu verstehen. Das Ding sollte wie folgt funktionieren:
__wenn der "Player" eine Zahl eingibt und auf "Calculate" klickt, wird die Zahl in einem "Array" (in diesem Fall eine SyncList) gespeichert
__gibt derselbe oder ein anderer Player eine zweite Zahl ein und klickt wiederum auf "Calculate", dann werden die beiden Zahlen addiert und jeder "Player" erhält das Ergebnis

Für den Host funktioniert das, und das Ergebnis wird auch am Client angezeigt. Aber das PROBLEM ist, dass es umgekehrt nicht geht, weil der Client die entspr. Command-Methode aufgrund einer fehlenden Berechtigung ("authority") nicht aufrufen kann.
Ich hab schon einiges dazu recherchiert, aber ich bekomme es einfacht nicht hin. Bin echt schon am verzweifeln. Denn ich glaube, dass das der entscheidende Schritt wäre, damit das Networking klappt...
Vielleicht hat jemand eine Idee?
