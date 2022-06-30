import React from 'react';
import styles from './index.module.css';

export type Props = {
  title: React.ReactNode,
  description: React.ReactNode,
  extra?: React.ReactNode,
}

export default function ({title, description, extra}: Props) : JSX.Element {

  return (
    <div className={styles.container}>
      <div className={styles.title}>{title}</div>
      <div className={styles.description}>{description}</div>
      {extra && <div className={styles.extra}>{extra}</div>}
    </div>
  );
}
