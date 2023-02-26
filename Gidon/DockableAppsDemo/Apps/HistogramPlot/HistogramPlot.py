import sys
import time

import numpy as np

from matplotlib.backends.qt_compat import QtWidgets
from matplotlib.backends.backend_qtagg import FigureCanvas
from matplotlib.figure import Figure
from BroadcastingRelayClient import BroadcastingRelayClient
import sys;

class ApplicationWindow(QtWidgets.QMainWindow):
    def __init__(self):
        super().__init__()
        self._main = QtWidgets.QWidget()
        self.setCentralWidget(self._main)
        layout = QtWidgets.QVBoxLayout(self._main)
        layout.setContentsMargins(0,0,0,0)

        canvas = FigureCanvas()
        layout.addWidget(canvas)

        plt = canvas.figure.subplots()

        mu, sigma = 100, 15
        x = mu + sigma * np.random.randn(10000)

        # the histogram of the data
        n, bins, patches = plt.hist(x, 50, density=True, facecolor='g', alpha=0.75)

        plt.set_xlabel('Smarts')
        plt.set_ylabel('Probability')
        plt.set_title('Histogram of IQ')
        plt.text(60, 0.025, r'$\mu=100,\ \sigma=15$')
        plt.axis([40, 160, 0, 0.03])
        plt.grid(True)

        self._ax = plt;

def main(argv):
    sys.path.append(r'..\CommonPython\env\Lib\site-packages')

    import Messages_pb2 as messages

    # Check whether there is already a running QApplication (e.g., if running
    # from an IDE).
    qapp = QtWidgets.QApplication.instance()
    if not qapp:
        qapp = QtWidgets.QApplication(sys.argv)

    app = ApplicationWindow()
    app.show()
    app.activateWindow()
    
    winhandle = int(app.winId())
    print(winhandle);

    winInfo = messages.WindowInfo()

    if len(argv) > 0:
        app.unique_window_host_id = argv[0];

        broadcastingClient = BroadcastingRelayClient("localhost", 5051)

        broadcastingClient.connect_if_needed()

        winInfo = messages.WindowInfo(WindowHandle=winhandle, UniqueWindowHostId=app.unique_window_host_id)
        broadcastingClient.broadcast_object(winInfo, "WindowInfoTopic", 1)

    app.raise_()
    qapp.exec()

if __name__ == "__main__":
    main(sys.argv[1:])


