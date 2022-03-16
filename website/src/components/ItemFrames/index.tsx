import React from 'react';

export type Props = {
  columns?: number,
  children?: React.ReactNode,
}

export default function ({columns, children}: Props) : JSX.Element {
  return (
    <div style={{display:'grid',gridTemplateColumns:'auto '.repeat(columns ?? 1).trimEnd()}}>
      {children}
    </div>
  );
}
