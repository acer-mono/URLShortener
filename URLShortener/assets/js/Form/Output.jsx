import React, { useState } from 'react';
import classNames from 'classnames';

export default ({response}) => {
    if (response && response.error === true) {
        const title = response.title || 'Error';
        const message = response.message || 'Unknown error';

        return (
            <div className="output">
                <div className="output__error">
                    {`${title}: ${message}`}
                </div>
            </div>
        );
    }
    
    if (!response || !response.url) {
        return '';
    }
    
    const [isUrlCopiedToClipboard, setIsUrlCopiedToClipboard] = useState(false);
    
    const buttonClassNames = classNames({
        'output__copy': true,
        'output__copy--ok': isUrlCopiedToClipboard === true
    });
    
    const copyToClipboard = async event => {
        await navigator.clipboard.writeText(response.url);
        setIsUrlCopiedToClipboard(true);
    };
    
    return (
        <div className="output">
            <div className="output__short-url">{response.url}</div>
            <button
                className={buttonClassNames}
                type="button"
                title="Copy to Clipboard"
                onClick={copyToClipboard}>
                Copy to Clipboard
            </button>
        </div>
    );
};
