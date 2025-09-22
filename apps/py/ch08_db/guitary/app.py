import os
import sys

folder = os.path.abspath(os.path.join(os.path.dirname(__file__), '..'))
sys.path.insert(0, folder)

import flask  # noqa: E402
from guitary.services import catalog_service  # noqa: E402
from guitary.data import session_factory  # noqa: E402
from guitary.data import data_loader  # noqa: E402

app = flask.Flask(__name__)


@app.route('/')
def index():
    return flask.render_template('index.html')


@app.route('/guitars')
@app.route('/guitars/<style>')
def guitars(style: str = None):
    guitar_list = catalog_service.all_guitars(style)
    return flask.render_template('guitars.html', guitars=guitar_list)


def configure():
    session_factory.global_init('guitary.sqlite')
    session_factory.create_tables()
    data_loader.load_guitars_if_empty()


def main():
    configure()
    app.run(debug=True)


if __name__ == '__main__':
    main()
else:
    configure()
