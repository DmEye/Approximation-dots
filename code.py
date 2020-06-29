from matplotlib import pyplot as plt
import numpy as np

dots = []

class dot:
    def __init__(self, x, y):
        self.x = x
        self.y = y

def print_arr(a):
    for i in a:
        print(i.x, ", ", i.y)
        print()

def onMouseEvent(event):
    global dots
    dots.append(dot(event.xdata, event.ydata))
    print_arr(dots)


x = np.arange(0, 5 * np.pi, 0.01)
y = np.sin(x) * np.cos(3 * x)
fig = plt.figure()
plt.plot(x, y)

button_press_event_id = fig.canvas.mpl_connect('button_press_event', onMouseEvent)

plt.show()

fig.canvas.mpl_disconnect(button_press_event_id)
