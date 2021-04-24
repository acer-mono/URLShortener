import React from 'react';
import ReactDOM from 'react-dom';
import '../img/clipboard.svg';

const layout = (
    <div className="layout">
        <form action="" className="form">
            <input className="form__input" type="text" placeholder="Enter a URL and press Enter" />
            <div className="form__result">
                <div className="form__shortened-url">https://u.rl/sAbUkz</div>
                <button
                    className="form__copy-to-clipboard"
                    type="button"
                    title="Copy to Clipboard">Copy to Clipboard</button>
            </div>
        </form>
    </div>
);

ReactDOM.render(layout, document.getElementById('root'));
