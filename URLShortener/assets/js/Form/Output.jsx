import React, { useState } from 'react';
import classNames from 'classnames';

export default props => {
    if (!props.response || !props.response.url) {
        return '';
    }
    
    const [isUrlCopiedToClipboard, setIsUrlCopiedToClipboard] = useState(false);
    
    const buttonClassNames = classNames({
        'output__copy': true,
        'output__copy--ok': isUrlCopiedToClipboard === true
    });
    
    return (
        <div className="output">
            <div className="output__short-url">{props.response.url}</div>
            <button
                className={buttonClassNames}
                type="button"
                title="Copy to Clipboard"
                onClick={copyToClipboard(props.response.url, setIsUrlCopiedToClipboard)}>
                Copy to Clipboard
            </button>
        </div>
    );
};

function copyToClipboard(url, setIsUrlCopiedToClipboard) {
    return async event => {
        await navigator.clipboard.writeText(url);
        setIsUrlCopiedToClipboard(true);
    }
}