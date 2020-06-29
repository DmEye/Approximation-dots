from matplotlib import pyplot as plt
import numpy as np

dots = [] # хранит все точки
# для отрисовки
x = []
y = []

class dot:
    def __init__(self, x, y):
        self.x = x
        self.y = y

def onMouseEvent(event):
    global dots
    global x
    global y
    dots.append(dot(event.xdata, event.ydata))
    for i in dots:
        x.append(i.x)
        y.append(i.y)
    plt.scatter(x, y)
    plt.show()

fig = plt.figure()

button_press_event_id = fig.canvas.mpl_connect('button_press_event', onMouseEvent)

plt.show()

fig.canvas.mpl_disconnect(button_press_event_id)
