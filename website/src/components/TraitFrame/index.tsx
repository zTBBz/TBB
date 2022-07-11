import React from 'react';
import styles from './index.module.css';

export type Props = {
  title: React.ReactNode,
  description: React.ReactNode,
  extra?: React.ReactNode,
  stats?: React.ReactNode,
  strength?: React.ReactNode,
  accuracy?: React.ReactNode,
  endurance?: React.ReactNode,
  speed?: React.ReactNode,
  CCPV?: React.ReactNode,
}

export default function ({title, description, extra, strength, accuracy, endurance, speed, CCPV}: Props) : JSX.Element {

  return (
    <div className={styles.container}>
      <div className={styles.title}>{title}</div>
      <div className={styles.description}>{description}</div>
      <div className={styles.stats}>
        {<b>Strength: </b>}{strength}<br/>
        {<b>Accuracy: </b>}{accuracy}<br/>
        {<b>Endurance: </b>}{endurance}<br/>
        {<b>Speed: </b>}{speed}<br/>
      </div>
      <div className={styles.CCPV}>
        {<b>CCPV: </b>}{CCPV}<br/>
      </div>
      {extra && <div className={styles.extra}>{extra}</div>}
    </div>
  );
}
